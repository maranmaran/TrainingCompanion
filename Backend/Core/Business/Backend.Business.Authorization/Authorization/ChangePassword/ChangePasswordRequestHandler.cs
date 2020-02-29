using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Authorization.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Authorization.Authorization.ChangePassword
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest>
    {
        private readonly IApplicationDbContext _context;

        public ChangePasswordRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken);

                user.PasswordHash = PasswordHasher.GetPasswordHash(request.Password);

                if (!user.Active)
                    user.Active = true;

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not change password.", e);
            }
        }
    }
}