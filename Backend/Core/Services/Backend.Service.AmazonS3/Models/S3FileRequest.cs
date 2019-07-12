namespace Backend.Service.AmazonS3.Models
{
    public class S3FileRequest
    {
        public string FileName { get; set; }

        public S3FileRequest(string fileName)
        {
            FileName = fileName;
        }
    }
}
