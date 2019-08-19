using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.Delete
{
    public class DeleteExerciseTypePropertyRequestHandler : IRequestHandler<DeleteExerciseTypePropertyRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExerciseTypePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExerciseTypePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseTypeProperty =
                    await _context.ExerciseTypeProperties.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.ExerciseTypeProperties.Remove(exerciseTypeProperty);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ExerciseTypeProperty), e);
            }
        }
    }
}