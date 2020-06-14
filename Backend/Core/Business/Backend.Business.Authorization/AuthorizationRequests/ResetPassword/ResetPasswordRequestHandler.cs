using Backend.Business.Email.Requests.ResetPasswordEmail;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using Backend.Library.Email;
using Backend.Library.Email.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Authorization.AuthorizationRequests.ResetPassword
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ResetPasswordRequestHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

                if (user == null)
                {
                    throw new NotFoundException(nameof(ApplicationUser), request.Email);
                }

                await _mediator.Send(new ResetPasswordEmailRequest(user), cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(
                    $"Could not send reset password email to user with email {request.Email}", e);
            }
        }
    }
}