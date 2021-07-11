using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Interfaces;
using Backend.Library.AmazonS3.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IStorage _storage;
        private readonly JsonSerializerSettings _serializerSettings;

        public ActivityService(IStorage storage)
        {
            _storage = storage;
            _serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>()
                {
                    new StringEnumConverter()
                }
            };
        }

        public async Task<string> GetEntityAsJson(AuditRecord audit)
        {
            return audit.EntityType switch
            {
                nameof(Training) => JsonConvert.SerializeObject(await DeserializeTraining(audit), _serializerSettings),
                nameof(MediaFile) => JsonConvert.SerializeObject(await DeserializeMediaFile(audit), _serializerSettings),
                nameof(Bodyweight) => JsonConvert.SerializeObject(await DeserializeBodyweight(audit), _serializerSettings),
                nameof(PersonalBest) => JsonConvert.SerializeObject(await DeserializePersonalBest(audit), _serializerSettings),
                _ => throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}"),
            };
        }

        private async Task<TrainingDeserializeResult> DeserializeTraining(AuditRecord audit)
        {
            return await Task.FromResult(audit.GetData<TrainingDeserializeResult>().Entity);
        }

        private async Task<MediaFileDeserializeResult> DeserializeMediaFile(AuditRecord audit)
        {
            var mediaFile = audit.GetData<MediaFileDeserializeResult>().Entity;
            var ftpFilepath = mediaFile.FtpFilePath; // where it is stored on ftp (in this case storage)
            var publicUrl = mediaFile.DownloadUrl; // public url which may have expired already

            if (_storage.IsUrlExpired(publicUrl))
                publicUrl = await _storage.GetUrlAsync(ftpFilepath);

            mediaFile.DownloadUrl = publicUrl;
            return mediaFile;
        }

        private async Task<BodyweightDeserializeResult> DeserializeBodyweight(AuditRecord audit)
        {
            return await Task.FromResult(audit.GetData<BodyweightDeserializeResult>().Entity);
        }

        private async Task<PersonalBestDeserializeResult> DeserializePersonalBest(AuditRecord audit)
        {
            return await Task.FromResult(audit.GetData<PersonalBestDeserializeResult>().Entity);
        }
    }
}