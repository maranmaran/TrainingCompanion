using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseProperty.Create
{
    public class CreateExercisePropertyRequestHandler :
        IRequestHandler<CreateExercisePropertyRequest, Domain.Entities.ExerciseType.ExerciseProperty>
    {
        private readonly IApplicationDbContext _context;

        public CreateExercisePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.ExerciseType.ExerciseProperty> Handle(CreateExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var property = new Domain.Entities.ExerciseType.ExerciseProperty()
                {
                    Value = request.Value,
                    ExercisePropertyTypeId = request.ExercisePropertyTypeId
                };

                _context.ExerciseProperties.Add(property);

                await _context.SaveChangesAsync(cancellationToken);

                return property;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}