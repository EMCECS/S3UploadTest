/**
Copyright (c) 2016 EMC Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy of this 
software and associated documentation files (the "Software"), to deal in the Software 
without restriction, including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
permit persons to whom the Software is furnished to do so, subject to the following 
conditions:

The above copyright notice and this permission notice shall be included in all copies 
or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S3UploadTest
{
    public class TestData
    {
        public string Name { set; get; }
        public byte[] Data { set; get; }
    }

    public class S3TestHarness
    {
        private DateTime startTime;

        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Endpoint { get; set; }
        public int ObjectCount { get; set; }
        public int ObjectSize { get; set; }
        public int BufferSize { get; set; }
        public int MinThreads { get; set; }
        public int MaxConnections { get; set; }
        public Form1 Parent { set; get; }
        public bool UseVhostBuckets { get; set; }
        public bool NoCleanup { get; set; }

        public int FailureCount { get { return failureCount; } }
        private int failureCount;
        public int SuccessCount { get { return successCount; } }
        private int successCount;

        public TimeSpan Duration { get; private set; }

        AmazonS3Client s3;
        private string bucketName;
        private List<TestData> data;

        public S3TestHarness()
        {
            BufferSize = -1;
            successCount = 0;
            failureCount = 0;
            MinThreads = -1;
            MaxConnections = -1;
            UseVhostBuckets = false;
        }

        public void Start()
        {
            try {
                Parent.LogCreate("Initializing Connection...");
                connect();

                Parent.LogCreate("Creating Bucket...");
                createBucket();

                Parent.LogCreate("Generating Test Data...");
                generateTestData();

                Parent.LogCreate("Uploading Objects...");
                startTime = DateTime.Now;
                runTest();
                Duration = DateTime.Now - startTime;
                Parent.LogCreate("Upload Complete.");

                if (NoCleanup)
                {
                    Parent.LogCreate(string.Format("Cleanup skipped, see bucket {0}", bucketName));
                } else { 
                    Parent.LogCreate("Cleaning up objects");
                    cleanupObjects();

                    Parent.LogCreate("Removing test bucket...");
                    deleteBucket();
                }


                printSummary();
            } catch (Exception e)
            {
                Parent.LogCreate(string.Format("CRITICAL FAILURE: {0}\r\n{1}", e.Message, e.StackTrace));
            }
        }

        private void connect()
        {
            AmazonS3Config config = new AmazonS3Config()
            {
                ForcePathStyle = (!UseVhostBuckets),
                SignatureVersion = "2",
                ServiceURL = Endpoint
            };
            if(MaxConnections != -1)
            {
                config.ConnectionLimit = MaxConnections;
            }

            if(BufferSize != -1)
            {
                config.BufferSize = BufferSize;
            }
            s3 = new AmazonS3Client(new BasicAWSCredentials(AccessKey, SecretKey), config);

            Parent.LogCreate(string.Format(" - Buffer size is {0} bytes", s3.Config.BufferSize));
            Parent.LogCreate(string.Format(" - Connection limit is {0}", s3.Config.ConnectionLimit));
        }

        private void createBucket()
        {
            bucketName = Guid.NewGuid().ToString("D");
            s3.PutBucket(new PutBucketRequest()
            {
                BucketName = bucketName
            });
        }

        private void generateTestData()
        {
            // Generate random data.  ECS may exhibit abnormally high performance 
            // for compressible data.
            Random r = new Random();
            byte[] bytes = new byte[ObjectSize];
            r.NextBytes(bytes);

            data = new List<TestData>();
            for(int i = 0; i < ObjectCount; i++)
            {
                data.Add(new TestData() {
                    Name = Guid.NewGuid().ToString("D"),
                    Data = bytes
                });
            }
        }

        private void runTest()
        {
            int workerThreads = 0;
            int ioThreads = 0;

            ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
            Parent.LogCreate(string.Format(" - Min threads: worker: {0} IO: {1}", workerThreads, ioThreads));

            if(MinThreads != -1)
            {
                Parent.LogCreate(string.Format(" -> Setting Min worker threads to {0}", MinThreads));
                bool success = ThreadPool.SetMinThreads(MinThreads, ioThreads);
                if (!success)
                {
                    Parent.LogCreate("  FAILED!");
                }
            }

            ParallelOptions opts = new ParallelOptions();
            // Don't bother forking more threads than connections.
            opts.MaxDegreeOfParallelism = s3.Config.ConnectionLimit;

            Parallel.ForEach(data, opts, d => {
                try
                {
                    s3.PutObject(new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = d.Name,
                        InputStream = new MemoryStream(d.Data)
                    });
                    Interlocked.Increment(ref successCount);
                } catch(Exception e)
                {
                    Interlocked.Increment(ref failureCount);
                    Parent.LogCreate(string.Format("Error uploading {0}: {1}", d.Name, e.ToString()));
                }

            });
        }

        private void cleanupObjects()
        {
            ListObjectsResponse resp = null;
            do
            {
                if(resp == null)
                {
                    resp = s3.ListObjects(bucketName);
                } else
                {
                    // Continue listing from marker
                    resp = s3.ListObjects(new ListObjectsRequest()
                    {
                        BucketName = bucketName,
                        Marker = resp.NextMarker
                    });
                }
                Parallel.ForEach(resp.S3Objects, obj => {
                    s3.DeleteObject(new DeleteObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = obj.Key
                    });
                });
            } while (resp.IsTruncated);
        }

        private void deleteBucket()
        {
            s3.DeleteBucket(new DeleteBucketRequest()
            {
                BucketName = bucketName
            });
        }

        private void printSummary()
        {
            double objPerSec = (double)SuccessCount / Duration.TotalSeconds;
            double mbPerSec = ((double)SuccessCount * (double)ObjectSize / (1024.0 * 1024.0)) / Duration.TotalSeconds;
            Parent.LogCreate(string.Format("Uploaded {0} objects in {1}ms: {2:F2} obj/s {3:F2} MB/s, {4} Failures", SuccessCount, Duration.TotalMilliseconds, objPerSec, mbPerSec, FailureCount));
        }

    }
}
