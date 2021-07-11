using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3.Interfaces
{
    public interface IStorage
    {
        /// <summary>
        /// Gets a stream of data of the specified file from bucket
        /// </summary>
        Task<Stream> GetStreamAsync(string key);

        /// <summary>
        /// Writes the given stream of data to bucket
        /// TODO: Change to void
        /// </summary>
        Task<Stream> WriteAsync(string key, Stream data);

        /// <summary>
        /// Checks if given URL is valid
        /// </summary>
        Task<bool> ValidateUrlAsync(string url);

        /// <summary>
        /// Gets url
        /// </summary>
        Task<string> GetUrlAsync(string key);

        /// <summary>
        /// Checks if url is expired
        /// </summary>
        bool IsUrlExpired(string url);

        /// <summary>
        /// Refreshes url if needed.
        /// </summary>
        Task<string> RefreshUrlAsync(string url, string filename);

        /// <summary>
        /// Gets key depending on entity
        /// </summary>
        string GetKey(string entityType, Guid userId, string filename = null);
    }
}