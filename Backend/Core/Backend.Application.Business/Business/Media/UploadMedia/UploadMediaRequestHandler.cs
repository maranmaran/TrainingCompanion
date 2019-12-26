using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.AmazonS3.Models;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Media.UploadMedia
{
    /// <summary>
    /// Upload media request handler
    /// Saves media directly to s3 and SQL. Provides media presigned URL for easy download and display
    /// </summary>
    public class UploadMediaRequestHandler : IRequestHandler<UploadMediaRequest, MediaFile>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3AccessService _s3AccessService;

        public UploadMediaRequestHandler(IS3AccessService s3AccessService, IApplicationDbContext context)
        {
            _s3AccessService = s3AccessService;
            _context = context;
        }

        public async Task<MediaFile> Handle(UploadMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // save to s3
                var filename = GetFilename(request);
                var fileRequest = new S3FileRequest(filename);

                await _s3AccessService.WriteStreamToS3(fileRequest, request.File.OpenReadStream());
                var presignedUrl = await _s3AccessService.GetPresignedUrlAsync(fileRequest);

                // create db object and map to it
                var media = new MediaFile()
                {
                    ApplicationUserId = request.UserId,
                    TrainingId = request.TrainingId,
                    ExerciseId = request.ExerciseId,
                    DownloadUrl = presignedUrl,
                    Type = request.Type,
                    DateModified = DateTime.UtcNow,
                    DateUploaded = DateTime.UtcNow,
                    Filename = request.File.FileName,
                    FtpFilePath = filename,
                };

                // save to db
                await _context.MediaFiles.AddAsync(media, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                // return created object id or whole object
                return media;
            }
            catch (Exception ex)
            {
                throw new CreateFailureException($"Could not upload media {request.File.FileName}", ex);
            }
        }

        public string GetFilename(UploadMediaRequest request)
        {
            var builder = new StringBuilder();

            if (request.UserId != Guid.Empty)
                builder.Append($"media/{request.UserId}");

            if (!request.TrainingId.IsNullOrEmpty())
                builder.Append($"/training/{request.TrainingId}");

            if (!request.ExerciseId.IsNullOrEmpty())
                builder.Append($"/exercise/{request.ExerciseId}");

            builder.Append($"{request.TrainingId.ToString()}/{Guid.NewGuid()}");

            return builder.ToString();
        }
    }
}