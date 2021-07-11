using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingPrograms.DayRequests.Delete
{
    public class DeleteTrainingBlockDayRequestHandler : IRequestHandler<DeleteTrainingBlockDayRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingBlockDayRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTrainingBlockDayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingBlockDays.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.TrainingBlockDays.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlockDay), e);
            }
        }
    }
}