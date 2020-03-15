using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingLog.ExerciseRequests.Delete
{
    public class DeleteExerciseRequestHandler : IRequestHandler<DeleteExerciseRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExerciseRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exercise =
                    await _context.Exercises.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.Exercises.Remove(exercise);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.TrainingLog.Exercise), e);
            }
        }
    }
}