namespace Backend.Service.AmazonS3
{
    public class S3Settings
    {
        public string AccesKey { get; set; }
        public string SecretAccessKey { get; set; }
        public string BucketName { get; set; }
        public int MilisecondsBeforeRetry { get; set; }
        public int MaxRetryTimes { get; set; }

        public S3Settings()
        {
        }

        public S3Settings(string accessKey, string secretAccessKey, string bucketName, int millisecondsBeforeRetry, int maxRetryTimes)
        {
            AccesKey = accessKey;
            SecretAccessKey = secretAccessKey;
            BucketName = bucketName;
            MilisecondsBeforeRetry = millisecondsBeforeRetry;
            MaxRetryTimes = maxRetryTimes;
        }
    }
}