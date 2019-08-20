using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.GetAll
{
    public class GetAllExercisePropertyRequestHandler : IRequestHandler<GetAllExercisePropertyRequest, IQueryable<Domain.Entities.ExerciseType.ExerciseProperty>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExercisePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Domain.Entities.ExerciseType.ExerciseProperty>> Handle(GetAllExercisePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.ExerciseProperties.Where(x => x.ExercisePropertyTypeId == request.ExercisePropertyTypeId));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.ExerciseProperty), $"Could not find exercise type property with id: {request.ExercisePropertyTypeId} for {request.UserId} USER", e);
            }
        }
    }
}