using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingLog.Exercise.GetAll
{
    public class GetAllExerciseRequestHandler : IRequestHandler<GetAllExerciseRequest, IQueryable<Domain.Entities.TrainingLog.Exercise>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExerciseRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.TrainingLog.Exercise>> Handle(GetAllExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exercises = _context.Exercises
                    .Include(x => x.ExerciseType)
                        .ThenInclude(x => x.Properties)
                        .ThenInclude(x => x.Tag)
                        .ThenInclude(x => x.TagGroup)
                    .Include(x => x.Sets)
                    .Where(x => x.TrainingId == request.TrainingId);

                return Task.FromResult(exercises);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Exercise), $"Could not find exercise for {request.TrainingId} Training", e);
            }
        }
    }
}