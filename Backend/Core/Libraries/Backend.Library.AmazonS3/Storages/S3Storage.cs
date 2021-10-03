using Amazon.S3;
using Amazon.S3.Model;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using Backend.Library.AmazonS3.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3.Storages
{
    internal class S3Storage : IStorage
    {
        private readonly IStorageSettings _settings;
        private readonly IAmazonS3 _client;

        public S3Storage(IStorageSettings settings, IAmazonS3 client)
        {
            _settings = settings;
            _client = client;
        }

        public async Task<Stream> WriteAsync(string key, Stream data, string contentType, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            var request = new GetObjectRequest
            {
                BucketName = _settings.BucketName,
                Key = key,
            };

            try
            {
                var response = await _client.GetObjectAsync(request, cancellationToken);
                return response.ResponseStream;
            }
            catch (Exception e)
            {
                throw new Exception($"Key: {key}", e);
            }
        }

        public Task<bool> ValidateUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            return string.IsNullOrWhiteSpace(url) ? Task.FromResult(false) : Task.FromResult(url.Contains(_settings.BucketName) || url.Contains("media/"));
        }

        public Task<string> GetUrlAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            var request = new GetPreSignedUrlRequest()
            {
                BucketName = _settings.BucketName,
                Key = key,
                Expires = GetExpirationDate(),
            };

            try
            {
                return Task.FromResult(_client.GetPreSignedURL(request));
            }
            catch (Exception e)
            {
                throw new Exception($"Key: {key}", e);
            }
        }

        public bool IsUrlExpired(string url)
        {
            var regex = new Regex("-Expires=(\\d+)");
            var unixExpiryTimestamp = regex.Match(url).Groups[1].Value;

            var expiryDateOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(unixExpiryTimestamp));

            var expiryDate = expiryDateOffset.UtcDateTime;

            return DateTime.Compare(expiryDate, DateTime.UtcNow) < 0; // t1 is earlier than t2
        }

        public Task<string> RefreshUrlAsync(string url, string filename, CancellationToken cancellationToken = default)
        {
            // get fresh presigned url for display
            if (!string.IsNullOrWhiteSpace(url) && IsUrlExpired(url))
            {
                return GetUrlAsync(filename, cancellationToken);
            }

            return Task.FromResult(url);
        }

        // TODO: Ideally this isn't part of library but outside consumer
        public string GetKey(string entityType, Guid userId, string filename = null)
        {
            if (string.IsNullOrWhiteSpace(filename))
                filename = Guid.NewGuid().ToString();

            return entityType switch
            {
                nameof(TrainingProgram) => $"media/{userId}/training-program/{filename}",
                nameof(ApplicationUser.Avatar) => $"media/{userId}/avatar/{filename}",
                nameof(ChatMessage) => $"media/chat/{userId}/{filename}",
                _ => throw new ArgumentException($"Entity {entityType} not recognized. Can't construct s3 key")
            };
        }

        private DateTime GetExpirationDate()
        {
            // set culture
            var enCulture = new CultureInfo("en-US");
            var oldCulture = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = enCulture;

            var dt = DateTime.UtcNow.AddDays(7); // get date
            Thread.CurrentThread.CurrentCulture = oldCulture; // return culture

            return dt; // return date
        }
    }
}