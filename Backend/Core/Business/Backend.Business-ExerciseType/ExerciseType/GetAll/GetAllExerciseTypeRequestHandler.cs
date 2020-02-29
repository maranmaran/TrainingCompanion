using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business_ExerciseType.ExerciseType.GetAll
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
                var exerciseTypes = _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .Where(x => x.ApplicationUserId == request.UserId);

                //TODO: Technical debt.. this needs to be done better
                foreach (var exerciseType in exerciseTypes)
                {
                    exerciseType.Properties = exerciseType.Properties.Where(x => x.Show).ToList();
                }

                return Task.FromResult(exerciseTypes.AsQueryable());
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.ExerciseType), $"Could not find exercise type for {request.UserId} USER", e);
            }
        }
    }
}