using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.GetByMonth
{
    public class GetAllTrainingByMonthRequestHandler : IRequestHandler<GetAllTrainingsByMonthRequest, IEnumerable<Domain.Entities.TrainingLog.Training>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public GetAllTrainingByMonthRequestHandler(IApplicationDbContext context, IS3Service s3)
        {
            _context = context;
            _s3 = s3;
        }

        public async Task<IEnumerable<Domain.Entities.TrainingLog.Training>> Handle(GetAllTrainingsByMonthRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainings = await _context.Trainings

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

                    .Where(x => x.ApplicationUserId == request.ApplicationUserId &&
                                x.DateTrained.Month == request.Month &&
                                x.DateTrained.Year == request.Year)

                    .OrderBy(x => x.DateTrained)
                    .ToListAsync(cancellationToken);


                await RefreshPresignedUrls(trainings);

                return trainings;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.ApplicationUserId} USER", e);
            }
        }

        /// <summary>
        /// Refresh all pre-signed urls that need to be refreshed
        /// </summary>
        /// <param name="trainings"></param>
        /// <returns></returns>
        private async Task RefreshPresignedUrls(IEnumerable<Domain.Entities.TrainingLog.Training> trainings)
        {
            var trainingsWithMedia = trainings.Where(x => x.Media.Count + x.Exercises.Aggregate(0, (cur, exercise) => cur += exercise.Media.Count) > 0);

            foreach (var training in trainingsWithMedia)
            {
                foreach (var media in training.Media)
                {
                    media.DownloadUrl = await _s3.RenewPresignedUrl(media.DownloadUrl, media.FtpFilePath);
                }

                foreach (var exercise in training.Exercises)
                {
                    foreach (var media in exercise.Media)
                    {
                        media.DownloadUrl = await _s3.RenewPresignedUrl(media.DownloadUrl, media.FtpFilePath);

                        // aggregate into training media also for preview
                        training.Media.Add(media);
                    }
                }
            }
        }
    }
}