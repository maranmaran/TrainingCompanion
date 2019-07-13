using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;

namespace Backend.Application.Business.Business.Authorization.ChangePassword
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordRequestHandler(IPasswordHasher passwordHasher, IApplicationDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken);

                user.PasswordHash = _passwordHasher.GetPasswordHash(request.Password);

                if (user.AccountStatus == AccountStatus.Waiting)
                    user.AccountStatus = AccountStatus.Active;

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new PasswordException($"Could not change password.", e);
            }
        }
    }
}

