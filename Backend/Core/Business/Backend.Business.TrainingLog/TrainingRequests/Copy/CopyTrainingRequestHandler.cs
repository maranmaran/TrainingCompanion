using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.Copy
{
    public class CopyTrainingRequestHandler : IRequestHandler<CopyTrainingRequest, Training>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CopyTrainingRequestHandler> _logger;

        public CopyTrainingRequestHandler(IApplicationDbContext context, ILogger<CopyTrainingRequestHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Training> Handle(CopyTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training =
                    await _context
                        .Trainings
                        .Include(x => x.Exercises)
                            .ThenInclude(x => x.ExerciseType)
                            .ThenInclude(x => x.Properties)
                            .ThenInclude(x => x.Tag)
                            .ThenInclude(x => x.TagGroup)
                        .Include(x => x.Exercises)
                            .ThenInclude(x => x.Sets)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == request.TrainingId, cancellationToken);

                if (training == null)
                    throw new NotFoundException(nameof(training), request.TrainingId);

                training.Id = Guid.Empty;
                foreach (var exercise in training.Exercises)
                {
                    exercise.Id = Guid.Empty;
                    _context.Entry(exercise.ExerciseType).State = EntityState.Unchanged;

                    foreach (var set in exercise.Sets)
                    {
                        set.Id = Guid.Empty;
                    }
                }

                training.DateTrained = request.ToDate;
                training.TrainingBlockDayId = request.ToProgramDay;

                await _context.Trainings.AddAsync(training, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return training;
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not copy training. {e.Message} {e.InnerException?.Message}");
                throw new Exception("Could not copy training", e);
            }
        }
    }
}