using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Delete
{
    public class DeletePersonalBestRequestHandler : IRequestHandler<DeletePersonalBestRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonalBestRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonalBestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.PBs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                _context.PBs.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(DeletePersonalBestRequest), e);
            }
        }
    }
}