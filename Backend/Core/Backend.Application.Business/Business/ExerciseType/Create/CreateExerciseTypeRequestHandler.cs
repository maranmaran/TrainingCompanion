using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseType.Create
{
    public class CreateExerciseTypeRequestHandler : 
        IRequestHandler<CreateExerciseTypeRequest, Domain.Entities.ExerciseType.ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.ExerciseType.ExerciseType> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseType = _mapper.Map<Domain.Entities.ExerciseType.ExerciseType>(request);

                _context.ExerciseTypes.Add(exerciseType);
                await _context.SaveChangesAsync(cancellationToken);

                return exerciseType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseType), e);
            }
        }
    }
}