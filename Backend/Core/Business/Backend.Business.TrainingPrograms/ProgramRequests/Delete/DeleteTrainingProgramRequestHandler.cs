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
                var entity = await _context
                    .TrainingPrograms
                    .Include(x => x.Users)
                    .Include(x => x.TrainingBlocks)
                    .ThenInclude(x => x.Days)
                    .ThenInclude(x => x.Trainings)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                // unassign users
                if (entity.Users.IsNullOrEmpty() == false)
                {
                    foreach (var programUser in entity.Users)
                    {
                        var futureTrainings = _context.Trainings.Where(x =>
                            x.TrainingProgramId == programUser.TrainingProgramId &&
                            x.ApplicationUserId == programUser.ApplicationUserId &&
                            x.DateTrained >= DateTime.UtcNow);

                        // delete future trainings and connection
                        _context.TrainingProgramUsers.Remove(programUser);
                        _context.Trainings.RemoveRange(futureTrainings);
                    }
                }

                // remove all trainings from all days which are only part of training program (not assigned)
                //var trainingsToDelete = entity.TrainingBlocks.SelectMany(x => x.Days).SelectMany(x => x.Trainings);
                //_context.Trainings.RemoveRange(trainingsToDelete);

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