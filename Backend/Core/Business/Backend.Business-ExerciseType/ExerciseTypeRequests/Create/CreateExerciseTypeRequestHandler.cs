using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Create
{
    public class CreateExerciseTypeRequestHandler :
        IRequestHandler<CreateExerciseTypeRequest, ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseType> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseType = _mapper.Map<ExerciseType>(request);

                _context.ExerciseTypes.Add(exerciseType);
                await _context.SaveChangesAsync(cancellationToken);

                return exerciseType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseType), e);
            }
        }
    }
}