using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.TrainingRequests.Delete
{
    public class DeleteTrainingRequestHandler : IRequestHandler<DeleteTrainingRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTrainingRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var training = await _context.Trainings
                    .Include(x => x.Media)
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Media)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                var trainingMedia = training.Media;
                if (trainingMedia.IsNullOrEmpty() == false)
                    _context.MediaFiles.RemoveRange(trainingMedia);

                var exerciseMedia = training.Exercises.SelectMany(x => x.Media).ToList();
                if (exerciseMedia.IsNullOrEmpty() == false)
                    _context.MediaFiles.RemoveRange(exerciseMedia);

                _context.Trainings.Remove(training);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.TrainingLog.Training), e);
            }
        }
    }
}