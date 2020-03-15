using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Delete
{
    public class DeleteBodyweightRequestHandler : IRequestHandler<Delete.DeleteBodyweightRequest, Unit>
    {
        private readonly IApplicationDbContext _context;


        public DeleteBodyweightRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(Delete.DeleteBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entity = await _context.Bodyweights.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                _context.Bodyweights.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Delete.DeleteBodyweightRequest), e);
            }
        }
    }
}