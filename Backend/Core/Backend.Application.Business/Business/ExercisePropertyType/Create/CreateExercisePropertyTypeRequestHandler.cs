using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.Create
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
                var entity = _mapper.Map<Domain.Entities.ExerciseType.ExercisePropertyType>(request);

                await _context.ExercisePropertyTypes.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), e);
            }
        }
    }
}