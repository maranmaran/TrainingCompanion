﻿using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.MediaCompression.Interfaces;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.UploadTrainingMedia
{
    /// <summary>
    /// Upload media request handler
    /// Saves media directly to s3 and SQL. Provides media presigned URL for easy download and display
    /// </summary>
    public class UploadTrainingMediaRequestHandler : IRequestHandler<UploadTrainingMedia, MediaFile>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorage _storage;
        private readonly IMediaCompressionService _compressionService;

        public UploadTrainingMediaRequestHandler(IStorage storage, IApplicationDbContext context, IMediaCompressionService compressionService)
        {
            _storage = storage;
            _context = context;
            _compressionService = compressionService;
        }

        public async Task<MediaFile> Handle(UploadTrainingMedia request, CancellationToken cancellationToken)
        {
            try
            {
                // save to s3
                var filename = GetFilename(request);

                var file = request.File.OpenReadStream();

                // compress - TODO: Do this for videos also.. make compression service
                if (request.Type == MediaType.Image)
                    file = await _compressionService.Compress(MediaType.Image, request.File.OpenReadStream());

                await _storage.WriteAsync(filename, file, request.File.ContentType, cancellationToken);
                var presignedUrl = await _storage.GetUrlAsync(filename);

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

        public string GetFilename(UploadTrainingMedia request)
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