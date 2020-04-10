using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Deserializators
{
    public class MediaFileDeserializeResult
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string FtpFilePath { get; set; }
        public string DownloadUrl { get; set; }
        public MediaType Type { get; set; }

        public DateTime DateUploaded { get; set; }
        public DateTime DateModified { get; set; }

        public Guid ApplicationUserId { get; set; }

        public Guid? TrainingId { get; set; }

        public Guid? ExerciseId { get; set; }
    }
}