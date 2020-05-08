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
        private readonly IS3Service _s3;
        private readonly JsonSerializerSettings _serializerSettings;

        public ActivityService(IS3Service s3)
        {
            _s3 = s3;
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
            var ftpFilepath = mediaFile.FtpFilePath; // where it is stored on ftp (in this case s3)
            var publicUrl = mediaFile.DownloadUrl; // public url which may have expired already

            if (_s3.CheckIfPresignedUrlIsExpired(publicUrl))
                publicUrl = await _s3.GetPresignedUrlAsync(ftpFilepath);

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
