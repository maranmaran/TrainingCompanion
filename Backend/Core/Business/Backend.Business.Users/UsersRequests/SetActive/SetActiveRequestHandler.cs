using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Users.UsersRequests.SetActive
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
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.Id);

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