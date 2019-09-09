using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Training.GetAll
{
    public class GetTrainingRequestHandler : IRequestHandler<GetTrainingRequest, Domain.Entities.TrainingLog.Training>
    {
        private readonly IApplicationDbContext _context;

        public GetTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Domain.Entities.TrainingLog.Training> Handle(GetTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training = _context.Trainings

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)

                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.ExerciseProperty)
                    .ThenInclude(x => x.ExercisePropertyType)

                    .FirstOrDefault(x => x.Id == request.TrainingId);

                return Task.FromResult(training);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Training), $"Could not find training for {request.TrainingId} Training", e);
            }
        }
    }
}