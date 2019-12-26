using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities.Media
{
    public class MediaFile
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string FtpFilePath { get; set; }
        public string DownloadUrl { get; set; }
        public MediaType Type { get; set; }

        public DateTime DateUploaded { get; set; }
        public DateTime DateModified { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid? TrainingId { get; set; }
        public TrainingLog.Training Training { get; set; }

        public Guid? ExerciseId { get; set; }
        public TrainingLog.Exercise Exercise { get; set; }
    }
}