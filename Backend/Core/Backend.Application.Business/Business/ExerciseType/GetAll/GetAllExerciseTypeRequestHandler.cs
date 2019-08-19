using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseType.GetAll
{
    public class GetAllExerciseTypeRequestHandler : IRequestHandler<GetAllExerciseTypeRequest, IQueryable<Domain.Entities.ExerciseType.ExerciseType>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.ExerciseType.ExerciseType>> Handle(GetAllExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.ExerciseTypes.AsQueryable());
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.ExerciseType), $"Could not find exercise type for {request.UserId} USER", e);
            }
        }
    }
}