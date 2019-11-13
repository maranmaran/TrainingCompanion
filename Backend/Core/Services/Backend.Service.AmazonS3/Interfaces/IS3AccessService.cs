using Backend.Service.AmazonS3.Models;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Service.AmazonS3.Interfaces
{
    public interface IS3AccessService
    {
        /// <summary>
        /// Gets a stream of data from the specified file on our S3 bucket
        /// </summary>
        Task<Stream> GetFromS3(S3FileRequest request);

        /// <summary>
        /// Writes the given STRING to S3
        /// </summary>
        Task WriteStringToS3(S3FileRequest request, string data);

        /// <summary>
        /// Writes the given STREAM to S3
        /// </summary>
        Task WriteStreamToS3(S3FileRequest request, Stream data);

        /// <summary>
        /// Gets presigned url
        /// Default expiration date is 8 days
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> GetPresignedUrlAsync(S3FileRequest request);

        /// <summary>
        /// Checks if url is expired
        /// Returns true if expired
        /// Returns false if not expired
        /// </summary>
        bool CheckIfPresignedUrlIsExpired(string url);

        /// <summary>
        /// Refreshes presigned url if it's expired. Else it returns the same one that was given as input
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        Task<string> RenewPresignedUrl(string url, string filename);
    }
}
