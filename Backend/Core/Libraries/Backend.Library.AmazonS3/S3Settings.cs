using System;

namespace Backend.Library.AmazonS3
{
    public class S3Settings
    {
        public string AccesKey { get; set; }
        public string SecretAccessKey { get; set; }
        public string BucketName { get; set; }

        public S3Settings()
        {
        }

        public S3Settings(string accessKey, string secretAccessKey, string bucketName)
        {
            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));
            if (string.IsNullOrWhiteSpace(secretAccessKey))
                throw new ArgumentNullException(nameof(secretAccessKey));
            if (string.IsNullOrWhiteSpace(bucketName))
                throw new ArgumentNullException(nameof(bucketName));

            AccesKey = accessKey;
            SecretAccessKey = secretAccessKey;
            BucketName = bucketName;
        }
    }
}