namespace Backend.Library.AmazonS3
{
    public interface IStorageSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public string UrlBase { get; set; }
    }
}