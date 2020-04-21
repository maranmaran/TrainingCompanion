using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.TrainingProgramMaker;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.TrainingPrograms.BlockRequests.Delete
{
    public class DeleteTrainingBlockRequestHandler : IRequestHandler<DeleteTrainingBlockRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTrainingBlockRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(DeleteTrainingBlockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.TrainingBlocks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.TrainingBlocks.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(TrainingBlock), e);
            }
        }
    }
}