using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Delete
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
                var entity = await _context.TrainingPrograms.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.TrainingPrograms.Remove(entity);

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