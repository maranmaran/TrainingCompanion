using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.Create
{
    public class CreateExerciseTypePropertyRequestHandler : 
        IRequestHandler<CreateExerciseTypePropertyRequest, ExerciseTypeProperty>
    {
        private readonly IApplicationDbContext _context;

        public CreateExerciseTypePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExerciseTypeProperty> Handle(CreateExerciseTypePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var property = new ExerciseTypeProperty()
                {
                    Value = request.Value,
                    ExerciseTypePropertyType = request.Type
                };

                _context.ExerciseTypeProperties.Add(property);

                await _context.SaveChangesAsync(cancellationToken);

                return property;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseTypeProperty), e);
            }
        }
    }
}