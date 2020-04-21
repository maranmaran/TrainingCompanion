using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.DayRequests.GetAll
{
    public class GetAllTrainingBlockDaysRequestHandler : IRequestHandler<GetAllTrainingBlockDaysRequest, IEnumerable<TrainingBlockDay>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTrainingBlockDaysRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TrainingBlockDay>> Handle(GetAllTrainingBlockDaysRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _context.TrainingBlockDays

                    .Include(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)

                    .Include(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.ExerciseType)
                    .ThenInclude(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)

                    .Where(x => x.TrainingBlockId == request.TrainingBlockId)
                    .ToListAsync(cancellationToken);

                return entities;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(IEnumerable<TrainingBlockDay>), e);
            }
        }
    }
}