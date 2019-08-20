using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.UpdateMany
{
    public class UpdateManyExercisePropertyTypeRequestHandler : IRequestHandler<UpdateManyExercisePropertyTypeRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateManyExercisePropertyTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateManyExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var requestExerciseProperty in request.ExercisePropertyTypes)
                {
                    _context.ExercisePropertyTypes.Update(requestExerciseProperty);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}