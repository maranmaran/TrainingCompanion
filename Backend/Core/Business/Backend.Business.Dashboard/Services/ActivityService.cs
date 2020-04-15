using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Interfaces;
using Backend.Library.AmazonS3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IS3Service _s3;

        public ActivityService(IS3Service s3)
        {
            _s3 = s3;
        }

        public async Task<string> GetEntityAsJson(AuditRecord audit)
        {
            return audit.EntityType switch
            {
                nameof(Training) => JsonConvert.SerializeObject(await DeserializeTraining(audit)),
                nameof(MediaFile) => JsonConvert.SerializeObject(await DeserializeMediaFile(audit)),
                nameof(Bodyweight) => JsonConvert.SerializeObject(await DeserializeBodyweight(audit)),
                nameof(PersonalBest) => JsonConvert.SerializeObject(await DeserializePersonalBest(audit)),
                _ => throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}"),
            };
        }

        private async Task<TrainingDeserializeResult> DeserializeTraining(AuditRecord audit)
        {
            return audit.GetData<TrainingDeserializeResult>().Entity;
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
            return audit.GetData<BodyweightDeserializeResult>().Entity;
        }

        private async Task<PersonalBestDeserializeResult> DeserializePersonalBest(AuditRecord audit)
        {
            return audit.GetData<PersonalBestDeserializeResult>().Entity;
        }

    }
}
