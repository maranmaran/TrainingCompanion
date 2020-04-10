using Backend.Business.Dashboard.Interfaces;
using Backend.Domain;
using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
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

        public async Task<string> GetPayload(AuditRecord audit, UserSetting settings)
        {
            return audit.EntityType switch
            {
                nameof(Training) => await GetTrainingPayload(audit, settings),
                nameof(MediaFile) => await GetMediaFilePayload(audit, settings),
                nameof(Bodyweight) => await GetBodyweightPayload(audit, settings),
                nameof(PersonalBest) => await GetPersonalBestPayload(audit, settings),
                _ => throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}"),
            };
        }

        public string GetEntityAsJson(AuditRecord audit)
        {
            return audit.EntityType switch
            {
                nameof(Training) => JsonConvert.SerializeObject(audit.GetData<TrainingDeserializeResult>().Entity),
                nameof(MediaFile) => JsonConvert.SerializeObject(audit.GetData<MediaFileDeserializeResult>().Entity),
                nameof(Bodyweight) => JsonConvert.SerializeObject(audit.GetData<BodyweightDeserializeResult>().Entity),
                nameof(PersonalBest) => JsonConvert.SerializeObject(audit.GetData<PersonalBestDeserializeResult>().Entity),
                _ => throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}"),
            };
        }

        private async Task<string> GetTrainingPayload(AuditRecord audit, UserSetting settings)
        {
            var data = audit.GetData<TrainingDeserializeResult>();
            return "added new training";
        }

        private async Task<string> GetMediaFilePayload(AuditRecord audit, UserSetting settings)
        {
            var data = audit.GetData<MediaFileDeserializeResult>();
            var ftpFilepath = data.Entity.FtpFilePath; // where it is stored on ftp (in this case s3)
            var publicUrl = data.Entity.DownloadUrl; // public url which may have expired already

            if (_s3.CheckIfPresignedUrlIsExpired(publicUrl))
                publicUrl = await _s3.GetPresignedUrlAsync(ftpFilepath);

            return $"attached new media <img clas=\"img-fluid\" src=\"{publicUrl}\"/>";
        }

        private async Task<string> GetBodyweightPayload(AuditRecord audit, UserSetting settings)
        {
            var data = audit.GetData<BodyweightDeserializeResult>();
            var value = data.Entity.Value.FromMetricTo(settings.UnitSystem);
            var label = settings.UnitSystem.GetUnitLabel();

            return $"logged bodyweight of {value} {label}";
        }
        private async Task<string> GetPersonalBestPayload(AuditRecord audit, UserSetting settings)
        {
            var data = audit.GetData<PersonalBestDeserializeResult>();

            return "has new PR!";
        }

    }
}
