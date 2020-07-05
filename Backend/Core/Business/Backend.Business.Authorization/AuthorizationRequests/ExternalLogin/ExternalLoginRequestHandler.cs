using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Business.Authorization.AuthorizationRequests.ExternalLogin.GoogleLogin;
using Backend.Business.Authorization.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Factories;
using Backend.Library.Payment.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Authorization.AuthorizationRequests.ExternalLogin
{
    public class ExternalLoginRequestHandler : IRequestHandler<ExternalLoginRequest, ExternalLoginResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public ExternalLoginRequestHandler(IApplicationDbContext context,
            IMediator mediator,
            IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _mediator = mediator;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<ExternalLoginResponse> Handle(ExternalLoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

                if (user == null)
                {
                    // call create user request..
                    user = new ApplicationUser()
                    {
                        AccountType = request.AccountType,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        ExternalLoginAccount = true,
                        UserSetting = new UserSetting(),
                    };

                    if (request.Avatar != null)
                        user.Avatar = request.Avatar;

                    user.CustomerId = await StripeConfiguration.AddCustomer(user.FullName, user.Email); // add to stripe

                    user = ExerciseTagGroupsFactory.ApplyProperties<ApplicationUser>(user);

                    await _context.Users.AddAsync(user, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                var token = _tokenGenerator.GenerateToken(user.Id);

                var userInfo = await _mediator.Send(new CurrentUserRequest(user.Id), cancellationToken);

                return new ExternalLoginResponse(token, userInfo);
            }
            catch (Exception e)
            {
                throw new Exception(nameof(ExternalLoginRequest), e);
            }
        }
    }
}