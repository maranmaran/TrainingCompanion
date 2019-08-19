using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseType.Create
{
    public class CreateExerciseTypeRequestHandler : 
        IRequestHandler<CreateExerciseTypeRequest, Domain.Entities.ExerciseType.ExerciseType>
    {
        private readonly IApplicationDbContext _context;

        public CreateExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.ExerciseType.ExerciseType> Handle(CreateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return new Domain.Entities.ExerciseType.ExerciseType();
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Domain.Entities.ExerciseType.ExerciseType), e);
            }
        }
    }
}