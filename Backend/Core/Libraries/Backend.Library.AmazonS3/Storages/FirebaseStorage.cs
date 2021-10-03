using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.TrainingProgramMaker;
using Backend.Domain.Entities.User;
using Backend.Library.AmazonS3.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Upload;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Library.AmazonS3.Storages
{
    internal class FirebaseStorage : IStorage
    {
        private readonly IStorageSettings _settings;
        private readonly StorageClient _client;

        public FirebaseStorage(IStorageSettings settings)
        {
            _settings = settings;
            _client = StorageClient.Create(GoogleCredential.GetApplicationDefault());
        }


        public async Task<Stream> WriteAsync(string key, Stream data, string contentType, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            try
            {
                var uploader = _client.CreateObjectUploader(_settings.BucketName, key, contentType, data);

                var result = await uploader.UploadAsync(cancellationToken);

                if (result.Exception != null)
                    throw result.Exception;

                if (result.Status != UploadStatus.Completed)
                    throw new Exception($"Upload for {key} failed");

                return data;
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

        public async Task<string> GetUrlAsync(string key, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null");

            try
            {
                var obj = await _client.GetObjectAsync(_settings.BucketName, key, null, cancellationToken);
                return obj.MediaLink;
            }
            catch (Exception e)
            {
                throw new Exception($"Key: {key}", e);
            }
        }

        public bool IsUrlExpired(string url)
        {
            return false;
        }

        public Task<string> RefreshUrlAsync(string url, string filename, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

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
    }
}