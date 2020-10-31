using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3
{
    internal class S3Service : Interfaces.IS3Service
    {
        private readonly S3Settings _s3Settings;
        private readonly IAmazonS3 _s3Client;

        public S3Service(S3Settings s3Settings)
        {
            this._s3Settings = s3Settings;

            _s3Client = new AmazonS3Client(_s3Settings.AccesKey, _s3Settings.SecretAccessKey, Amazon.RegionEndpoint.EUCentral1);

        }

        public async Task<Stream> GetFromS3(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            var request = new GetObjectRequest
            {
                BucketName = _s3Settings.BucketName,
                Key = key,
            };

            try
            {
                var response = await _s3Client.GetObjectAsync(request);
                return response.ResponseStream;
            }
            catch (Exception e)
            {
                throw new Exception($"Key: {key}", e);
            }
        }

        public async Task WriteToS3(string key, Stream data)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            // new mem stream just in case
            await using var stream = new MemoryStream();
            await data.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);

            var request = new TransferUtilityUploadRequest()
            {
                BucketName = _s3Settings.BucketName,
                Key = key,
                InputStream = stream,
                AutoCloseStream = true,
            };

            var fileTransferUtility = new TransferUtility(_s3Client);

            await fileTransferUtility.UploadAsync(request);
        }

        public Task<bool> IsS3Url(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return Task.FromResult(false);

            return Task.FromResult(url.Contains(_s3Settings.BucketName) || url.Contains("media/"));
        }

        public async Task<string> GetPresignedUrlAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            var request = new GetPreSignedUrlRequest()
            {
                BucketName = _s3Settings.BucketName,
                Key = key,
                Expires = GetExpirationDate(),
            };

            try
            {
                return await Task.FromResult(_s3Client.GetPreSignedURL(request));
            }
            catch (Exception e)
            {
                throw new Exception($"Key: {key}", e);
            }
        }

        public bool CheckIfPresignedUrlIsExpired(string url)
        {
            var regex = new Regex("-Expires=(\\d+)");
            var unixExpieryTimestamp = regex.Match(url).Groups[1].Value;

            var expiryDateOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(unixExpieryTimestamp));

            var expiryDate = expiryDateOffset.UtcDateTime;

            return DateTime.Compare(expiryDate, DateTime.UtcNow) < 0; // t1 is earlier than t2
        }

        public async Task<string> RenewPresignedUrl(string url, string filename)
        {
            // get fresh presigned url for display
            if (
                !string.IsNullOrWhiteSpace(url) &&
                CheckIfPresignedUrlIsExpired(url))
            {
                return await GetPresignedUrlAsync(filename);
            }

            return url;
        }

        public string GetS3Key(string entityType, Guid userId, string filename = null)
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