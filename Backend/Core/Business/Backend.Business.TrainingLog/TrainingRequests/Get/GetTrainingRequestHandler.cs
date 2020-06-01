
using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.Get
{
    public class GetTrainingRequestHandler : IRequestHandler<GetTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3AccessService;
        private readonly ILoggingService _loggingService;

        public GetTrainingRequestHandler(IApplicationDbContext context, IS3Service s3AccessService, ILoggingService loggingService)
        {
            _context = context;
            _s3AccessService = s3AccessService;
            _loggingService = loggingService;
        }

        public async Task<Domain.Entities.TrainingLog.Training> Handle(GetTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training = _context.Trainings

                    .Include(x => x.TrainingProgram)
                    .Include(x => x.TrainingBlockDay)

                    .Include(x => x.Media)

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Media)

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)

                    .FirstOrDefault(x => x.Id == request.TrainingId);

                if (training == null)
                {
                    var ex = new NotFoundException(nameof(Training), request.TrainingId);
                    await _loggingService.LogError(ex, "Training could not be found");
                    throw ex;
                }

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