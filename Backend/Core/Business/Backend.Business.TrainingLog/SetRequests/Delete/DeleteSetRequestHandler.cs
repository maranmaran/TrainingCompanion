using Backend.Domain;
using Backend.Domain.Entities.TrainingLog;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.TrainingLog.SetRequests.Delete
{
    public class DeleteSetRequestHandler : IRequestHandler<DeleteSetRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSetRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSetRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var set =
                    await _context.Sets.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (set == null)
                    throw new NotFoundException(nameof(Set), request.Id);

                _context.Sets.Remove(set);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Domain.Entities.TrainingLog.Set), e);
            }
        }
    }
}