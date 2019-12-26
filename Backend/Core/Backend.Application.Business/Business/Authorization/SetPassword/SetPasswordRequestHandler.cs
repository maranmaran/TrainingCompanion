using Backend.Application.Business.Business.Authorization.CurrentUser;
using Backend.Application.Business.Business.Authorization.SignIn;
using Backend.Domain;
using Backend.Service.Authorization.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Authorization.SetPassword
{
    public class SetPasswordRequestHandler : IRequestHandler<SetPasswordRequest, (CurrentUserRequestResponse response, string token)>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public SetPasswordRequestHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<(CurrentUserRequestResponse response, string token)> Handle(SetPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == request.UserId, cancellationToken);
                user.PasswordHash = PasswordHasher.GetPasswordHash(request.Password);

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                // log user in...
                var signInRequest = new SignInRequest() { Password = request.Password, Username = user.Username };
                var response = await _mediator.Send(signInRequest, cancellationToken);

                return response;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not set new password for user with id: {request.UserId}", e);
            }
        }
    }
}