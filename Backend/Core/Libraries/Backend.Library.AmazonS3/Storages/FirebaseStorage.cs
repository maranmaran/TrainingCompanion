using Backend.Library.AmazonS3.Interfaces;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
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
            _client = StorageClient.Create();
        }

        public Task<Stream> GetStreamAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> WriteAsync(string key, Stream data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUrlAsync(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsUrlExpired(string url)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshUrlAsync(string url, string filename)
        {
            throw new NotImplementedException();
        }

        public string GetKey(string entityType, Guid userId, string filename = null)
        {
            throw new NotImplementedException();
        }
    }
}