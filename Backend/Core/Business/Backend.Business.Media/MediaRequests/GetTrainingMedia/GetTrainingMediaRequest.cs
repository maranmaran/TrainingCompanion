using Backend.Domain;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.GetTrainingMedia
{
    public class GetTrainingMediaRequest : IRequest<IEnumerable<MediaFile>>
    {
        public Guid TrainingId { get; set; }

        public GetTrainingMediaRequest(Guid trainingId)
        {
            TrainingId = trainingId;
        }
    }

    public class GetTrainingMediaRequestHandler : IRequestHandler<GetTrainingMediaRequest, IEnumerable<MediaFile>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStorage _storage;

        public GetTrainingMediaRequestHandler(IApplicationDbContext context, IStorage storage)
        {
            _context = context;
            _storage = storage;
        }

        public async Task<IEnumerable<MediaFile>> Handle(GetTrainingMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training =
                    await _context.Trainings
                        .Include(x => x.Media)
                        .FirstOrDefaultAsync(x => x.Id == request.TrainingId, cancellationToken);

                var media = training.Media;

                await RefreshPresignedUrls(media);

                return media;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Training), $"Could not find training for {request.TrainingId} Id", e);
            }
        }

        /// <summary>
        /// Refresh all pre-signed urls that need to be refreshed
        /// </summary>
        private async Task RefreshPresignedUrls(IEnumerable<MediaFile> mediaList)
        {
            foreach (var media in mediaList)
            {
                media.DownloadUrl = await _storage.RefreshUrlAsync(media.DownloadUrl, media.FtpFilePath);
            }
        }
    }
}