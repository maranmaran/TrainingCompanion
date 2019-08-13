using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities
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
    }
}
