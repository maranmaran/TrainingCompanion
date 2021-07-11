using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Get
{
    public class GetExerciseTypeRequestHandler : IRequestHandler<GetExerciseTypeRequest, ExerciseType>
    {
        private readonly IApplicationDbContext _context;

        public GetExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExerciseType> Handle(GetExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseType = await _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                // if we don't want to fetch inactive.. means we want to fetch active only
                if (exerciseType == null)
                    throw new NotFoundException(nameof(ExerciseType), request.Id);

                //TODO: Technical debt.. this needs to be done better
                exerciseType.Properties = exerciseType.Properties.Where(x => x.Show).ToList();

                return exerciseType;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ExerciseType), $"Could not find exercise type for id of {request.Id}", e);
            }
        }
    }
}