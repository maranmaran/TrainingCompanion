using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingLog.ExerciseRequests.Get
{
    public class GetExerciseRequestHandler : IRequestHandler<GetExerciseRequest, Domain.Entities.TrainingLog.Exercise>
    {
        private readonly IApplicationDbContext _context;

        public GetExerciseRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Domain.Entities.TrainingLog.Exercise> Handle(GetExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exercise = _context.Exercises
                    .Include(x => x.Sets)
                    .Include(x => x.ExerciseType)
                    .FirstOrDefault(x => x.Id == request.ExerciseId);

                return Task.FromResult(exercise);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.TrainingLog.Exercise), $"Could not find exercise for {request.ExerciseId} Exercise", e);
            }
        }
    }
}