using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.ExerciseRequests.Delete
{
    public class DeleteExerciseRequestHandler : IRequestHandler<DeleteExerciseRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggingService _logger;

        public DeleteExerciseRequestHandler(IApplicationDbContext context, ILoggingService logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteExerciseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // remove exercises
                var deletedExercise = await DeleteExercise(request.Id, cancellationToken);

                // update orders of other exercises inside training
                await UpdateOtherExerciseOrders(deletedExercise.TrainingId, deletedExercise.Id, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Exercise), e);
            }
        }

        private async Task<Exercise> DeleteExercise(Guid exerciseId, CancellationToken cancellationToken = default)
        {
            var exercise = await _context.Exercises
                .Include(x => x.Media)
                .FirstOrDefaultAsync(x => x.Id == exerciseId, cancellationToken);

            if (exercise == null)
            {
                await _logger.LogError($"Could not find exericse {exerciseId}");
                throw new NotFoundException(nameof(Exercise), exerciseId);
            }

            _context.MediaFiles.RemoveRange(exercise.Media);
            _context.Exercises.Remove(exercise);

            return exercise;
        }

        private async Task UpdateOtherExerciseOrders(Guid trainingId, Guid exerciseId, CancellationToken cancellationToken = default)
        {
            var exercisesToUpdate = await _context.Exercises.Where(x => x.TrainingId == trainingId && x.Id != exerciseId).OrderBy(x => x.Order).ToListAsync(cancellationToken);

            var idx = 0;
            foreach (var exercise in exercisesToUpdate)
            {
                exercise.Order = idx;
                idx++;
            }

            _context.Exercises.UpdateRange(exercisesToUpdate);
        }
    }
}