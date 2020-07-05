using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Business.Authorization.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Domain.Factories;
using Backend.Library.Payment.Configuration;
using Google.Apis.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.Business.Authorization.AuthorizationRequests.ExternalLogin
{
    public class ExternalLoginRequestHandler : IRequestHandler<ExternalLoginRequest, ExternalLoginResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public ExternalLoginRequestHandler(IApplicationDbContext context,
            IMediator mediator,
            IConfiguration configuration,
            IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _mediator = mediator;
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<ExternalLoginResponse> Handle(ExternalLoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var googleAuthSection = _configuration.GetSection("GoogleSettings");
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string>() { googleAuthSection["OAuthClientID"] }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(request.TokenId, settings);

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == payload.Email, cancellationToken);

                if (user == null)
                {
                    // TODO
                    // redirect to choose athlete / coach page
                    //return Redirect("http://localhost:4200/choose-account-type");

                    user = new ApplicationUser()
                    {
                        AccountType = AccountType.Coach,
                        Email = payload.Email,
                        FirstName = payload.Name.Split(" ")[0],
                        LastName = payload.Name.Split(" ")[1],
                        ExternalLoginAccount = true,
                        UserSetting = new UserSetting(),
                    };

                    if (payload.Picture != null)
                        user.Avatar = payload.Picture;

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