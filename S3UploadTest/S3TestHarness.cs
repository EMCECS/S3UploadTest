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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

        public int tps;
        public long bytesPerSec;
        public int errors;

        public TimeSpan Duration { get; private set; }

        List<AmazonS3Client> s3;
        Dictionary<AmazonS3Client, int> errorCount;
        Dictionary<AmazonS3Client, DateTime> penaltyBox;

        List<string> objectKeys;
        //List<string> blacklistedKeys;

        private string bucketName;
        private List<TestData> data;
        private Random r;

        private Timer pingTimer;
        private Timer statsTimer;
        private bool pingRunning;

        private byte[] randomBytes;

        public S3TestHarness()
        {
            BufferSize = -1;
            successCount = 0;
            failureCount = 0;
            MinThreads = -1;
            MaxConnections = -1;
            UseVhostBuckets = false;
            s3 = new List<AmazonS3Client>();
            errorCount = new Dictionary<AmazonS3Client, int>();
            penaltyBox = new Dictionary<AmazonS3Client, DateTime>();
            r = new Random();
            objectKeys = new List<string>();
            //blacklistedKeys = new List<string>();
        }

        public void Start()
        {
            try {
                Parent.LogOutput("Initializing Connection...");
                connect();

                // Check immediately in case nodes are unreachable from the start
                pingTimerCallback(null);
                pingTimer = new Timer(new TimerCallback(pingTimerCallback), null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
                statsTimer = new Timer(new TimerCallback(statUpdate), null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

                Parent.LogOutput("Creating Bucket...");
                createBucket();

                Parent.LogOutput("Generating Test Data...");
                generateTestData();

                Parent.LogOutput("Uploading Objects...");
                startTime = DateTime.Now;
                runTest();
                Duration = DateTime.Now - startTime;
                Parent.LogOutput("Upload Complete.");

                //Parent.LogOutput("Starting Read Test...");
                //readTest();
                //Parent.LogOutput("Read complete.");

                Parent.LogOutput("Starting Write Test...");
                overwriteTest();
                Parent.LogOutput("Write complete.");

                if (NoCleanup)
                {
                    Parent.LogOutput(string.Format("Cleanup skipped, see bucket {0}", bucketName));
                } else { 
                    Parent.LogOutput("Cleaning up objects");
                    cleanupObjects();

                    Parent.LogOutput("Removing test bucket...");
                    deleteBucket();
                }

                pingTimer.Dispose();
                pingTimer = null;
                statsTimer.Dispose();
                statsTimer = null;

                printSummary();
            } catch (Exception e)
            {
                Parent.LogOutput(string.Format("CRITICAL FAILURE: {0}\r\n{1}", e.Message, e.StackTrace));
            }
        }

        private void connect()
        {
            string[] endpoints = Endpoint.Split(',');
            foreach(string endpoint in endpoints)
            {

                AmazonS3Config config = new AmazonS3Config()
                {
                    ForcePathStyle = (!UseVhostBuckets),
                    SignatureVersion = "2",
                    ServiceURL = endpoint,
                    MaxErrorRetry = 0,
                    ReadWriteTimeout = TimeSpan.FromSeconds(15),
                    Timeout = TimeSpan.FromSeconds(15)
                };
                //ServicePoint sp = ServicePointManager.FindServicePoint(new Uri(endpoint));
                if (MaxConnections != -1)
                {
                    config.ConnectionLimit = MaxConnections;
                }

                if (BufferSize != -1)
                {
                    config.BufferSize = BufferSize;
                }
                s3.Add(new AmazonS3Client(new BasicAWSCredentials(AccessKey, SecretKey), config));
            }

            Parent.LogOutput(string.Format(" - Buffer size is {0} bytes", s3[0].Config.BufferSize));
            Parent.LogOutput(string.Format(" - Connection limit is {0}", s3[0].Config.ConnectionLimit));
        }

        private void createBucket()
        {
            bucketName = Guid.NewGuid().ToString("D");
            s3[0].PutBucket(new PutBucketRequest()
            {
                BucketName = bucketName
            });
        }

        private void generateTestData()
        {
            // Generate random data.  ECS may exhibit abnormally high performance 
            // for compressible data.
            Random r = new Random();
            randomBytes = new byte[ObjectSize];
            r.NextBytes(randomBytes);

            data = new List<TestData>();
            for(int i = 0; i < ObjectCount; i++)
            {
                data.Add(new TestData() {
                    Name = Guid.NewGuid().ToString("D"),
                    Data = randomBytes
                });
            }
        }

        private void runTest()
        {
            int workerThreads = 0;
            int ioThreads = 0;

            ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
            Parent.LogOutput(string.Format(" - Min threads: worker: {0} IO: {1}", workerThreads, ioThreads));

            if(MinThreads != -1)
            {
                Parent.LogOutput(string.Format(" -> Setting Min worker threads to {0}", MinThreads));
                bool success = ThreadPool.SetMinThreads(MinThreads, ioThreads);
                if (!success)
                {
                    Parent.LogOutput("  FAILED!");
                }
            }

            ParallelOptions opts = new ParallelOptions();
            // Don't bother forking more threads than connections.
            opts.MaxDegreeOfParallelism = s3[0].Config.ConnectionLimit;
            Parallel.ForEach(data, opts, d => {
                AmazonS3Client s3c = null;
                try
                {
                    s3c = getClient();
                    s3c.PutObject(new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = d.Name,
                        InputStream = new MemoryStream(d.Data)
                    });
                    Interlocked.Increment(ref successCount);
                    Interlocked.Increment(ref tps);
                    Interlocked.Add(ref bytesPerSec, d.Data.LongLength);
                    objectKeys.Add(d.Name);
                } catch(Exception e)
                {
                    Interlocked.Increment(ref failureCount);
                    Interlocked.Increment(ref tps);
                    Interlocked.Increment(ref errors);
                    Parent.LogOutput(string.Format("Error uploading {0}: {1}", d.Name, e.Message));
                    handleFailure(e, s3c);
                }

            });
        }


        private void readTest()
        {
            ParallelOptions opts = new ParallelOptions();
            // Don't bother forking more threads than connections.
            opts.MaxDegreeOfParallelism = s3[0].Config.ConnectionLimit;
            Parallel.For(0, 10000000, opts, i =>
            {
                AmazonS3Client s3c = null;
                string key = null;
                try
                {
                    key = getKey();
                    s3c = getClient();

                    GetObjectResponse resp = s3c.GetObject(new GetObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = key,                    
                    });
                    using (Stream s = resp.ResponseStream)
                    {
                        byte[] buffer = new byte[65536];
                        while (true)
                        {
                            int c = s.Read(buffer, 0, buffer.Length);
                            if (c == 0)
                            {
                                break;
                            }
                            Interlocked.Add(ref bytesPerSec, c);
                        }
                    }
                    Interlocked.Increment(ref tps);
                }
                catch (Exception e)
                {
                    Interlocked.Increment(ref failureCount);
                    Interlocked.Increment(ref tps);
                    Interlocked.Increment(ref errors);
                    Parent.LogOutput(string.Format("Error reading {0}: {1}, Connection: {2}", key, e.Message, s3c.Config.ServiceURL));
                    handleFailure(e, s3c);
                }
            });
        }

        private void overwriteTest()
        {
            ParallelOptions opts = new ParallelOptions();
            // Don't bother forking more threads than connections.
            opts.MaxDegreeOfParallelism = s3[0].Config.ConnectionLimit;
            Parallel.For(0, 10000000, opts, i =>
            {
                AmazonS3Client s3c = null;
                string key = null;
                try
                {
                    key = getKey();
                    s3c = getClient();

                    s3c.PutObject(new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = key,
                        InputStream = new MemoryStream(randomBytes)
                    });

                    Interlocked.Add(ref bytesPerSec, randomBytes.LongLength);
                    Interlocked.Increment(ref tps);
                }
                catch (Exception e)
                {
                    Interlocked.Increment(ref failureCount);
                    Interlocked.Increment(ref tps);
                    Interlocked.Increment(ref errors);
                    Parent.LogOutput(string.Format("Error writing {0}: {1}, Connection: {2}", key, e.Message, s3c.Config.ServiceURL));
                    handleFailure(e, s3c);
                }
            });
        }

        private string getKey()
        {
            lock(objectKeys)
            {
                return objectKeys[r.Next() % objectKeys.Count];
            }
        }


        private void cleanupObjects()
        {
            ListObjectsResponse resp = null;
            do
            {
                if(resp == null)
                {
                    resp = s3[0].ListObjects(bucketName);
                } else
                {
                    // Continue listing from marker
                    resp = s3[0].ListObjects(new ListObjectsRequest()
                    {
                        BucketName = bucketName,
                        Marker = resp.NextMarker
                    });
                    Interlocked.Increment(ref tps);
                }
                Parallel.ForEach(resp.S3Objects, obj => {
                    s3[0].DeleteObject(new DeleteObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = obj.Key
                    });
                    Interlocked.Increment(ref tps);
                });
            } while (resp.IsTruncated);
        }

        private void deleteBucket()
        {
            s3[0].DeleteBucket(new DeleteBucketRequest()
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

        // Our poor man's load balancer.
        private AmazonS3Client getClient()
        {
            
            lock(s3)
            {
                AmazonS3Client s3c = s3[r.Next() % s3.Count];

                return s3c;
            }

        }

        private void handleFailure(Exception e, AmazonS3Client s3c)
        {
            if(s3c == null)
            {
                return;
            }

            if(e is System.Net.Sockets.SocketException)
            {
                // Connection error; immediate penalty
                penalize(s3c);
            } else if(e is ProtocolViolationException)
            {
                // Same
                penalize(s3c);
            } else if(e.Message.Contains("ConnectFailure"))
            {
                penalize(s3c);
            } else
            {
                int c = 1;
                lock(errorCount)
                {
                    if (errorCount.ContainsKey(s3c))
                    {
                        c = errorCount[s3c] + 1;
                    }
                    errorCount[s3c] = c;
                    
                }
                if(c % 10 == 0)
                {
                    Debug.WriteLine(string.Format("WARN: Connection to {0} has {1} errors", s3c.Config.ServiceURL, c));
                }
            }
        }

        // Put the connection in the penalty box.
        private void penalize(AmazonS3Client s3c)
        {
            Debug.WriteLine(string.Format("WARN: Removing connection to {0}", s3c.Config.ServiceURL));
            lock (s3)
            {
                s3.Remove(s3c);

                // Don't allow everything in the penalty box...
                if(s3.Count == 0)
                {
                    Debug.WriteLine("CRITICAL: All connections in penalty box; jailbreak them and try again.");
                    lock (penaltyBox)
                    {
                        foreach (AmazonS3Client c in penaltyBox.Keys)
                        {
                            // we already have a lock on s3
                            s3.Add(c);
                            errorCount[c] = 0;
                        }
                        penaltyBox.Clear();
                    }
                    return;
                }

            }
            lock(penaltyBox)
            {
                penaltyBox[s3c] = DateTime.Now;
            }
            Debug.WriteLine("INFO: Connections: Good: {0} Bad {1}", s3.Count, penaltyBox.Count);
        }

        private void parole(AmazonS3Client s3c)
        {
            Debug.WriteLine("WARN: Re-adding node " + s3c.Config.ServiceURL);
            // Get locks in proper order
            lock(s3)
            {
                lock(penaltyBox)
                {
                    penaltyBox.Remove(s3c);
                }
                s3.Add(s3c);
            }
            Debug.WriteLine("INFO: Connections: Good: {0} Bad {1}", s3.Count, penaltyBox.Count);
        }


        /// <summary>
        /// Ping each node to check state.
        /// </summary>
        /// <param name="state"></param>
        private void pingTimerCallback(object state)
        {
            if (pingRunning) return;
            pingRunning = true;

            byte[] buffer = new byte[65536];

            // Copy the list in case it's modified
            List<AmazonS3Client> clients = new List<AmazonS3Client>();
            lock(s3)
            {
                clients.AddRange(s3);
            }
            foreach (AmazonS3Client s3c in clients)
            {
                string pinguri = s3c.Config.ServiceURL + "?ping";

                try
                {
                    WebRequest req = WebRequest.Create(pinguri);
                    req.Headers.Add("X-Emc-Namespace", "foo");
                    using (WebResponse resp = req.GetResponse())
                    {
                        using (Stream s = resp.GetResponseStream())
                        {
                            int c = s.Read(buffer, 0, buffer.Length);
                            if(c == 0)
                            {
                                Debug.WriteLine("WARN: Ping response was zero bytes");
                                penalize(s3c);
                            }
                            string responseText = Encoding.UTF8.GetString(buffer, 0, c);
                            if(responseText.Contains("<Name>MAINTENANCE_MODE</Name><Status>ON</Status>"))
                            {
                                Debug.WriteLine(string.Format("WARN: Node {0} is going into maintenance mode", s3c.Config.ServiceURL));
                                penalize(s3c);
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(string.Format("WARN: Ping '{0}' failed: {1}", pinguri, e.Message));
                    penalize(s3c);
                }
            }

            // Bring back nodes if they reappear
            clients.Clear();
            lock(penaltyBox)
            {
                clients.AddRange(penaltyBox.Keys);
            }
            foreach(AmazonS3Client s3c in clients)
            {
                string pinguri = s3c.Config.ServiceURL + "?ping";

                try
                {
                    WebRequest req = WebRequest.Create(pinguri);
                    req.Headers.Add("X-Emc-Namespace", "foo");
                    using (WebResponse resp = req.GetResponse())
                    {
                        using (Stream s = resp.GetResponseStream())
                        {
                            int c = s.Read(buffer, 0, buffer.Length);
                            if (c == 0)
                            {
                                //Debug.WriteLine("WARN: Ping response was zero bytes");
                                continue;
                            }
                            string responseText = Encoding.UTF8.GetString(buffer, 0, c);
                            if (responseText.Contains("<Name>MAINTENANCE_MODE</Name><Status>ON</Status>"))
                            {
                                //Debug.WriteLine(string.Format("WARN: Node {0} is going into maintenance mode", s3c.Config.ServiceURL));
                                continue;
                            }

                            if (responseText.Contains("<Name>MAINTENANCE_MODE</Name><Status>OFF</Status>") 
                                || responseText.Contains("<Name>MAINTENANCE_MODE</Name><Status>UNKNOWN</Status>"))
                            {
                                // If we got here, node looks okay.
                                parole(s3c);
                            }

                        }

                    }
                }
                catch (Exception)
                {
                    // Expected for penalized nodes to fail ping checks.
                }

            }
            pingRunning = false;
        }

        private void statUpdate(object state)
        {
            Debug.WriteLine(string.Format("== {0} ==", DateTime.Now));
            Debug.WriteLine("INFO: Connections: Good: {0} Bad {1}", s3.Count, penaltyBox.Count);
            Debug.WriteLine("INFO: Objects: Good: {0}", objectKeys.Count);
        }

    }
}
