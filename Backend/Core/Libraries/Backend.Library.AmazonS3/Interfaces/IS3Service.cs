using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3.Interfaces
{
    public interface IS3Service
    {
        /// <summary>
        /// Gets a stream of data from the specified file on our S3 bucket
        /// </summary>
        Task<Stream> GetFromS3(string key);

        /// <summary>
        /// Writes the given STREAM to S3
        /// </summary>
        Task WriteToS3(string key, Stream data);

        /// <summary>
        /// Checks if given URL belongs to S3
        /// </summary>
        Task<bool> IsS3Url(string url);

        /// <summary>
        /// Gets presigned url
        /// Default expiration date is 8 days
        /// </summary>
        Task<string> GetPresignedUrlAsync(string key);

        /// <summary>
        /// Checks if url is expired
        /// Returns true if expired
        /// Returns false if not expired
        /// </summary>
        bool CheckIfPresignedUrlIsExpired(string url);

        /// <summary>
        /// Refreshes presigned url if it's expired. Else it returns the same one that was given as input
        /// </summary>
        Task<string> RenewPresignedUrl(string url, string filename);

        /// <summary>
        /// Gets S3 key depending on entity
        /// </summary>
        /// <returns></returns>
        string GetS3Key(string entityType, Guid userId, string filename = null);
    }
}