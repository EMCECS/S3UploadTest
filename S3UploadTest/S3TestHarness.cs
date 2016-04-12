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
        public int ThreadCount { get; set; }
        public Form1 Parent { set; get; }

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
        }

        public void Start()
        {
            Parent.LogOutput("Initializing Connection...");
            connect();

            Parent.LogOutput("Creating Bucket...");
            createBucket();

            Parent.LogOutput("Generating Test Data...");
            generateTestData();

            Parent.LogOutput("Uploading Objects...");
            startTime = DateTime.Now;
            runTest();
            Duration = DateTime.Now - startTime;
            Parent.LogOutput("Upload Complete.");

            Parent.LogOutput("Cleaning up objects");
            cleanupObjects();

            Parent.LogOutput("Removing test bucket...");
            deleteBucket();

            printSummary();
        }

        private void connect()
        {
            AmazonS3Config config = new AmazonS3Config()
            {
                ConnectionLimit = ThreadCount,
                ForcePathStyle = true,
                SignatureVersion = "2",
                ServiceURL = Endpoint
            };

            if(BufferSize != -1)
            {
                config.BufferSize = BufferSize;
            }
            s3 = new AmazonS3Client(new BasicAWSCredentials(AccessKey, SecretKey), config);

            Parent.LogOutput(string.Format(" - Buffer size is {0} bytes", s3.Config.BufferSize));

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
            Parallel.ForEach(data, d => {
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
                    Parent.LogOutput(string.Format("Error uploading {0}: {1}", d.Name, e.ToString()));
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
            Parent.LogOutput(string.Format("Uploaded {0} objects in {1}ms: {2:F2} obj/s {3:F2} MB/s, {4} Failures", SuccessCount, Duration.TotalMilliseconds, objPerSec, mbPerSec, FailureCount));
        }

    }
}
