using AutoMapper;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Extensions;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Coaches.CreateCoach
{
    public class CreateCoachRequestHandler : IRequestHandler<CreateCoachRequest, Coach>
    {
        private readonly IApplicationDbContext _context;
        private readonly IStripeConfiguration _stripeConfiguration;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public CreateCoachRequestHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStripeConfiguration stripeConfiguration, IPasswordHasher passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _stripeConfiguration = stripeConfiguration;
            _passwordHasher = passwordHasher;
        }

        public async Task<Coach> Handle(CreateCoachRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var coach = _mapper.Map<CreateCoachRequest, Coach>(request);

                coach.CustomerId = await _stripeConfiguration.AddCustomer(coach.GetFullName(), coach.Email); // add to stripe
                coach.UserSettings = new UserSettings();

                coach.Avatar = new GenericAvatarConstructor().AddName(coach.GetFullName()).Round().Background().Foreground().Value();

                _context.Coaches.Add(coach);
                await _context.SaveChangesAsync(cancellationToken);

                return coach;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Coach), e);
            }
        }
    }
}
