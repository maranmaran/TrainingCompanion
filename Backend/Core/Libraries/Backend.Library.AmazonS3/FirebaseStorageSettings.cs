using System;

namespace Backend.Library.AmazonS3
{
    internal class FirebaseStorageSettings : IStorageSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public string UrlBase { get; set; }

        public FirebaseStorageSettings()
        {
        }

        public FirebaseStorageSettings(string accessKey, string secretKey, string bucketName)
        {
            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));
            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(nameof(secretKey));
            if (string.IsNullOrWhiteSpace(bucketName))
                throw new ArgumentNullException(nameof(bucketName));

            AccessKey = accessKey;
            SecretKey = secretKey;
            BucketName = bucketName;
        }
    }
}