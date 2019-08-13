using AutoMapper;
using Backend.Application.Business.Business.Authorization.SendRegistrationEmail;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Domain.Extensions;
using Backend.Service.Email;
using Backend.Service.Email.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IStripeConfiguration _stripeConfiguration;



        public CreateUserRequestHandler(
            IMediator mediator,
            IMapper mapper,
            IApplicationDbContext context,
            IStripeConfiguration stripeConfiguration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _stripeConfiguration = stripeConfiguration;
        }

        public async Task<ApplicationUser> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:
                        return await CreateCoach(request);

                    case AccountType.Athlete:
                        return await CreateAthlete(request);

                    case AccountType.SoloAthlete:
                        return await CreateSoloAthlete(request);

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }

            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ApplicationUser), e);
            }
        }

        private async Task<ApplicationUser> CreateCoach(CreateUserRequest request)
        {
            var coach = _mapper.Map<CreateUserRequest, Coach>(request);
            coach.CustomerId = await _stripeConfiguration.AddCustomer(coach.GetFullName(), coach.Email); // add to stripe

            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            await _mediator.Send(new SendRegistrationEmailRequest(coach));

            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> CreateAthlete(CreateUserRequest request)
        {
            var athlete = _mapper.Map<CreateUserRequest, Athlete>(request);

            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            await _mediator.Send(new SendRegistrationEmailRequest(athlete));

            // return data
            return _mapper.Map<ApplicationUser>(athlete);
        }

        private async Task<ApplicationUser> CreateSoloAthlete(CreateUserRequest request)
        {
            var soloAthlete = _mapper.Map<CreateUserRequest, SoloAthlete>(request);

            _context.SoloAthletes.Add(soloAthlete);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            await _mediator.Send(new SendRegistrationEmailRequest(soloAthlete));

            // return data
            return _mapper.Map<ApplicationUser>(soloAthlete);
        }
    }
}
