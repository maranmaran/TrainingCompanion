using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                var training =
                    await _context.Trainings.SingleAsync(x => x.Id == request.Id, cancellationToken);

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