using Backend.Common.Extensions;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Delete
{
    public class DeleteTrainingProgramRequestHandler : IRequestHandler<DeleteTrainingProgramRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingProgramRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTrainingProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var programUsers = await _context.TrainingProgramUsers
                    .Where(x => x.TrainingProgramId == request.Id).ToListAsync(cancellationToken);
                // unassign users
                if (programUsers.IsNullOrEmpty() == false)
                {
                    foreach (var programUser in programUsers)
                    {
                        var futureTrainings = await _context.Trainings
                                                                            .Include(x => x.Media)
                                                                            .Include(x => x.Exercises)
                                                                            .ThenInclude(x => x.Media)
                        .Where(x =>
                            x.TrainingProgramId == programUser.TrainingProgramId &&
                            x.ApplicationUserId == programUser.ApplicationUserId &&
                            x.DateTrained >= DateTime.UtcNow)
                        .ToListAsync(cancellationToken);

                        // take care of all media
                        var exerciseMediaToDelete = futureTrainings.SelectMany(x => x.Exercises).SelectMany(x => x.Media);
                        var trainingMediaToDelete = futureTrainings.SelectMany(x => x.Media);

                        _context.MediaFiles.RemoveRange(exerciseMediaToDelete);
                        _context.MediaFiles.RemoveRange(trainingMediaToDelete);

                        _context.Trainings.RemoveRange(futureTrainings);

                        // delete future trainings and connection
                        _context.TrainingProgramUsers.Remove(programUser);
                    }
                }

                var entity = await _context
                    .TrainingPrograms
                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                // remove all trainings from all days which are only part of training program(not assigned)
                var trainingsToDelete = entity.TrainingBlocks.SelectMany(x => x.Days).SelectMany(x => x.Trainings);
                _context.Trainings.RemoveRange(trainingsToDelete);

                // remove training program
                _context.TrainingPrograms.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(DeleteTrainingProgramRequest), e);
            }
        }
    }
}