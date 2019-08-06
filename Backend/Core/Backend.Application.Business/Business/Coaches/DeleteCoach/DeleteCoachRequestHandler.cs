using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Coaches.DeleteCoach
{
    public class DeleteCoachRequestHandler : IRequestHandler<DeleteCoachRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCoachRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCoachRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var coach = await _context.Coaches.SingleAsync(u => u.Id == request.CoachId, cancellationToken);

                _context.Coaches.Remove(coach);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Coach), request.CoachId, e.Message);
            }
        }
    }
}
