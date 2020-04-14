using Backend.Domain.Deserializators;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Library.AmazonS3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Backend.Infrastructure.Interfaces;

namespace Backend.Business.Dashboard.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IS3Service _s3;

        public ActivityService(IS3Service s3)
        {
            _s3 = s3;
        }

        //public async Task<string> GetPayload(AuditRecord audit, UserSetting settings)
        //{
        //    return audit.EntityType switch
        //    {
        //        nameof(Training) => await GetTrainingPayload(audit, settings),
        //        nameof(MediaFile) => await GetMediaFilePayload(audit, settings),
        //        nameof(Bodyweight) => await GetBodyweightPayload(audit, settings),
        //        nameof(PersonalBest) => await GetPersonalBestPayload(audit, settings),
        //        _ => throw new ArgumentException($"Entity type is not recognized. {audit.EntityType}"),
        //    };
        //}

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

        //private async Task<string> GetTrainingPayload(AuditRecord audit, UserSetting settings)
        //{
        //    var data = audit.GetData<TrainingDeserializeResult>();
        //    return "added new training";
        //}

        //private async Task<string> GetMediaFilePayload(AuditRecord audit, UserSetting settings)
        //{
        //    var data = audit.GetData<MediaFileDeserializeResult>();
        //    var ftpFilepath = data.Entity.FtpFilePath; // where it is stored on ftp (in this case s3)
        //    var publicUrl = data.Entity.DownloadUrl; // public url which may have expired already

        //    if (_s3.CheckIfPresignedUrlIsExpired(publicUrl))
        //        publicUrl = await _s3.GetPresignedUrlAsync(ftpFilepath);

        //    return $"attached new media <img clas=\"img-fluid\" src=\"{publicUrl}\"/>";
        //}

        //private async Task<string> GetBodyweightPayload(AuditRecord audit, UserSetting settings)
        //{
        //    var data = audit.GetData<BodyweightDeserializeResult>();
        //    var value = data.Entity.Value.FromMetricTo(settings.UnitSystem);
        //    var label = settings.UnitSystem.GetUnitLabel();

        //    return $"logged bodyweight of {value} {label}";
        //}
        //private async Task<string> GetPersonalBestPayload(AuditRecord audit, UserSetting settings)
        //{
        //    var data = audit.GetData<PersonalBestDeserializeResult>();

        //    return "has new PR!";
        //}

    }
}
