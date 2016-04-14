# S3UploadTest
Windows test app for parallel S3 uploads.

This application allows the user to exercise the .NET SDK for S3 to test parallel uploads.  Options are given to choose the number of objects to upload, the object size, and options to override the defaults for buffer size, min threads, and max connections.  These values can be used to test performance when uploading using .NET and to tune the various options to achieve maximum performance from your application.
