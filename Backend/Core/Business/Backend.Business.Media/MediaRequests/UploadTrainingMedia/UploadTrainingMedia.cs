using System;
using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Media.MediaRequests.UploadTrainingMedia
{
    /// <summary>
    /// Request class for upload of media
    /// </summary>
    public class UploadTrainingMedia : IRequest<MediaFile>
    {
        public Guid UserId { get; set; }
        public Guid? TrainingId { get; set; }
        public Guid? ExerciseId { get; set; }
        public IFormFile File { get; set; }
        public string Extension { get; set; }
        public MediaType Type { get; set; }

        public UploadTrainingMedia(Guid userId, IFormFile file, string extension, MediaType type)
        {
            UserId = userId;
            File = file;
            Extension = extension;
            Type = type;
        }

        public UploadTrainingMedia()
        {
        }
    }
}