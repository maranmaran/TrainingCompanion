using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseProperty.Create
{
    public class CreateExercisePropertyTypeRequestHandler : IRequestHandler<CreateExercisePropertyTypeRequest, Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExercisePropertyTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.ExercisePropertyType> Handle(CreateExercisePropertyTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var propertyType = _mapper.Map<Domain.Entities.ExerciseType.ExercisePropertyType>(request);

                _context.ExercisePropertyTypes.Add(propertyType);

                await _context.SaveChangesAsync(cancellationToken);

                return propertyType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}