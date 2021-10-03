using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3.Interfaces
{
    public interface IStorage
    {
        /// <summary>
        /// Writes the given stream of data to bucket
        /// </summary>
        Task<Stream> WriteAsync(string key, Stream data, string contentType, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if given URL is valid
        /// </summary>
        Task<bool> ValidateUrlAsync(string url, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets url
        /// </summary>
        Task<string> GetUrlAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if url is expired
        /// </summary>
        bool IsUrlExpired(string url);

        /// <summary>
        /// Refreshes url if needed.
        /// </summary>
        Task<string> RefreshUrlAsync(string url, string filename, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets key depending on entity
        /// TODO: This is not library concern. This belongs to business layer
        /// </summary>
        string GetKey(string entityType, Guid userId, string filename = null);
    }
}