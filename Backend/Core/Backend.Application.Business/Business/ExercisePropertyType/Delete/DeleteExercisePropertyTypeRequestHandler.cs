using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseProperty.Delete
{
    public class DeleteExercisePropertyTypeRequestHandler : IRequestHandler<DeleteExercisePropertyTypeRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExercisePropertyTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exercisePropertyType = await _context.ExercisePropertyTypes.SingleAsync(x => x.Id == request.Id, cancellationToken);

                _context.ExercisePropertyTypes.Remove(exercisePropertyType);

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