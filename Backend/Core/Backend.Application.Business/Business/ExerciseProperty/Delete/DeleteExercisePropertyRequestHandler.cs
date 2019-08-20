using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseProperty.Delete
{
    public class DeleteExercisePropertyRequestHandler : IRequestHandler<DeleteExercisePropertyRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExercisePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseProperty =
                    await _context.ExerciseProperties.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.ExerciseProperties.Remove(exerciseProperty);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}