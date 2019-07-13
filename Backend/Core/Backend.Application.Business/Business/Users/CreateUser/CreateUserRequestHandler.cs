using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Extensions;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;

namespace Backend.Application.Business.Business.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserRequestResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStripeConfiguration _stripeConfiguration;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserRequestHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStripeConfiguration stripeConfiguration, IPasswordHasher passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _stripeConfiguration = stripeConfiguration;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserRequestResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<CreateUserRequest, ApplicationUser>(request);
                user.PasswordHash = _passwordHasher.GetPasswordHash(request.Password);

                user.CustomerId = await _stripeConfiguration.AddCustomer(user.GetFullName(), user.Email); // add to stripe
                user.UserSettings = new UserSettings();

                user.Avatar = new GenericAvatarConstructor().AddName(user.GetFullName()).Round().Background().Foreground().Value();

                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ApplicationUser, CreateUserRequestResponse>(user);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ApplicationUser), e.Message);
            }
        }
    }
}
