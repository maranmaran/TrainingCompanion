using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingLog.TrainingRequests.GetByWeek
{
    public class GetAllTrainingByWeekRequestHandler : IRequestHandler<GetAllTrainingsByWeekRequest, IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingByWeekRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.TrainingLog.Training>> Handle(GetAllTrainingsByWeekRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trainings = _context.Trainings
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
                                                              x.DateTrained >= request.WeekStart &&
                                                              x.DateTrained <= request.WeekEnd);

                return Task.FromResult(trainings);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.ApplicationUserId} USER", e);
            }
        }
    }
}