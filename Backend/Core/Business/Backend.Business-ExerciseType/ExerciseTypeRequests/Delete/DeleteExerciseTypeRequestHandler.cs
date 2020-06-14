using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Delete
{
    public class DeleteExerciseTypeRequestHandler : IRequestHandler<DeleteExerciseTypeRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseType =
                    await _context.Tags.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (exerciseType == null)
                    throw new NotFoundException(nameof(ExerciseType), request.Id);

                _context.Tags.Remove(exerciseType);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ExerciseType), e);
            }
        }
    }
}