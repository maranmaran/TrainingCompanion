using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.ExerciseRequests.GetAll
{
    public class GetAllExerciseRequestHandler : IRequestHandler<GetAllExerciseRequest, IEnumerable<Exercise>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public GetAllExerciseRequestHandler(IApplicationDbContext context, IS3Service s3)
        {
            _context = context;
            _s3 = s3;
        }


        public async Task<IEnumerable<Exercise>> Handle(GetAllExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exercises = await _context.Exercises
                    .Include(x => x.Sets)
                    .Include(x => x.Media)
                    .Include(x => x.ExerciseType)
                        .ThenInclude(x => x.Properties)
                        .ThenInclude(x => x.Tag)
                        .ThenInclude(x => x.TagGroup)
                    .Where(x => x.TrainingId == request.TrainingId)
                    .ToListAsync(cancellationToken);

                await RefreshPresignedUrls(exercises);

                return exercises;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Exercise), $"Could not find exercises for {request.TrainingId} Training", e);
            }
        }

        /// <summary>
        /// Refresh all pre-signed urls that need to be refreshed
        /// </summary>
        private async Task RefreshPresignedUrls(IEnumerable<Exercise> exercises)
        {

            foreach (var exercise in exercises)
            {
                foreach (var media in exercise.Media)
                {
                    media.DownloadUrl = await _s3.RenewPresignedUrl(media.DownloadUrl, media.FtpFilePath);
                }
            }
        }


    }
}