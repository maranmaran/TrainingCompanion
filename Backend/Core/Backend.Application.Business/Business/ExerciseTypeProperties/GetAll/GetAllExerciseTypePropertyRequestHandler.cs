using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.GetAll
{
    public class GetAllExerciseTypePropertyRequestHandler : IRequestHandler<GetAllExerciseTypePropertyRequest, IQueryable<ExerciseTypeProperty>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExerciseTypePropertyRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<ExerciseTypeProperty>> Handle(GetAllExerciseTypePropertyRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_context.ExerciseTypeProperties.Where(x => x.ExerciseTypePropertyType == request.Type));
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ExerciseTypeProperty), $"Could not find exercise type properties of type {request.Type} for {request.UserId} USER", e);
            }
        }
    }
}