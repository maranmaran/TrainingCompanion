using Backend.Business.Authorization.AuthorizationRequests.CurrentUser;
using Backend.Business.Authorization.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Domain.Factories;
using Backend.Library.Payment.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

                // TODO: Extract this
                if (user == null)
                {
                    var notificationSettings = EnumFactory.SeedEnum<NotificationType, NotificationSetting>((value, index) => new NotificationSetting()
                    {
                        Id = Guid.NewGuid(),
                        NotificationType = value,
                    }).ToList();

                    // call create user request..
                    var userId = Guid.NewGuid();
                    var newUser = new ApplicationUser()
                    {
                        Id = userId,
                        AccountType = request.AccountType,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        ExternalLoginAccount = true,
                        UserSetting = new UserSetting()
                        {
                            ApplicationUserId = userId,
                            NotificationSettings = notificationSettings,
                        },
                    };

                    if (request.Avatar != null)
                        newUser.Avatar = request.Avatar;

                    newUser.CustomerId = await StripeConfiguration.AddCustomer(newUser.FullName, newUser.Email); // add to stripe

                    newUser = ExerciseTagGroupsFactory.ApplyProperties<ApplicationUser>(newUser);

                    await _context.Users.AddAsync(newUser, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);

                    user = newUser;
                }
                else if (user.ExternalLoginAccount == false)
                {
                    throw new Exception("Can't external login user who exists but doesn't have external login enabled");
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