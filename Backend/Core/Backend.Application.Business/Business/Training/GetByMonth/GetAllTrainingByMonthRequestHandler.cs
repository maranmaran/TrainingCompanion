using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Training.GetByMonth
{
    public class GetAllTrainingByMonthRequestHandler : IRequestHandler<GetAllTrainingsByMonthRequest, IQueryable<Domain.Entities.TrainingLog.Training>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingByMonthRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.TrainingLog.Training>> Handle(GetAllTrainingsByMonthRequest request, CancellationToken cancellationToken)
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
                                                              x.DateTrained.Month == request.Month &&
                                                              x.DateTrained.Year == request.Year);

                return Task.FromResult(trainings);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.ApplicationUserId} USER", e);
            }
        }
    }
}