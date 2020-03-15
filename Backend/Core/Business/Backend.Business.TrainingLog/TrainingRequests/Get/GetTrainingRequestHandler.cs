﻿
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.AmazonS3.Interfaces;

namespace Backend.Business.TrainingLog.TrainingRequests.Get
{
    public class GetTrainingRequestHandler : IRequestHandler<GetTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3AccessService;

        public GetTrainingRequestHandler(IApplicationDbContext context, IS3Service s3AccessService)
        {
            _context = context;
            _s3AccessService = s3AccessService;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(GetTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training = _context.Trainings

                    .Include(x => x.Media)

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Media)
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)

                    .FirstOrDefault(x => x.Id == request.TrainingId);

                // ef core can't sort include statements so we do that after fetching data
                training.Exercises = training.Exercises.OrderBy(x => x.Order).ToArray();

                await RefreshPresignedUrls(training);

                return training;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.TrainingId} Training", e);
            }
        }

        /// <summary>
        /// Refresh all pre-signed urls that need to be refreshed
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        private async Task RefreshPresignedUrls(Domain.Entities.TrainingLog.Training training)
        {
            foreach (var media in training.Media)
            {
                media.DownloadUrl = await _s3AccessService.RenewPresignedUrl(media.DownloadUrl, media.FtpFilePath);
            }

            foreach (var exercise in training.Exercises)
            {
                foreach (var media in exercise.Media)
                {
                    media.DownloadUrl = await _s3AccessService.RenewPresignedUrl(media.DownloadUrl, media.FtpFilePath);
                }
            }
        }
    }
}