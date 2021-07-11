using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.GetAll
{
    public class GetAllExerciseTypeRequestHandler : IRequestHandler<GetAllExerciseTypeRequest, IEnumerable<ExerciseType>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseType>> Handle(GetAllExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseTypes = _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .Where(x => x.ApplicationUserId == request.UserId);

                // if we don't want to fetch inactive.. means we want to fetch active only
                if (!request.FetchInactive)
                    exerciseTypes = exerciseTypes.Where(x => x.Active);

                //TODO: Technical debt.. this needs to be done better
                foreach (var exerciseType in exerciseTypes)
                {
                    exerciseType.Properties = exerciseType.Properties.Where(x => x.Show).ToList();
                }

                return await exerciseTypes.AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ExerciseType), $"Could not find exercise type for {request.UserId} USER", e);
            }
        }
    }
}