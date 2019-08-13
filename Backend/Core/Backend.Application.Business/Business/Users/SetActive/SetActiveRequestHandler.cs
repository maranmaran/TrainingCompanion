using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Users.SetActive
{
    public class SetActiveRequestHandler : IRequestHandler<SetActiveUserRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        public SetActiveRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SetActiveUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken);
                user.Active = request.Value;

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not set active: {request.Value} state on user: {request.Id}", e);
            }
        }
    }
}
