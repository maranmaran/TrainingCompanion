using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.Authorization.Authorization.SendRegistrationEmail;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Domain.Extensions;
using Backend.Domain.Factories;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserRequestHandler(
            IMediator mediator,
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
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
            coach.CustomerId = await StripeConfiguration.AddCustomer(coach.GetFullName(), coach.Email); // add to stripe

            coach = ExerciseTagGroupsFactory.ApplyProperties<Coach>(coach);

            await _context.Coaches.AddAsync(coach);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            await _mediator.Send(new SendRegistrationEmailRequest(coach));

            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> CreateAthlete(CreateUserRequest request)
        {
            var athlete = _mapper.Map<CreateUserRequest, Athlete>(request);
            var coach = await _context.Coaches.SingleAsync(x => x.Id == request.CoachId);

            // map exercise type properties from coach to athlete
            athlete = ExerciseTagGroupsFactory.ApplyProperties<Athlete>(coach, athlete);

            await _context.Athletes.AddAsync(athlete);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            try
            {
                await _mediator.Send(new SendRegistrationEmailRequest(athlete));
            }
            catch (Exception e)
            {
                // log
            }

            // return data
            return _mapper.Map<ApplicationUser>(athlete);
        }

        private async Task<ApplicationUser> CreateSoloAthlete(CreateUserRequest request)
        {
            var soloAthlete = _mapper.Map<CreateUserRequest, SoloAthlete>(request);
            soloAthlete = ExerciseTagGroupsFactory.ApplyProperties<SoloAthlete>(soloAthlete);

            await _context.SoloAthletes.AddAsync(soloAthlete);
            await _context.SaveChangesAsync();

            // send mail to complete registration
            await _mediator.Send(new SendRegistrationEmailRequest(soloAthlete));

            // return data
            return _mapper.Map<ApplicationUser>(soloAthlete);
        }
    }
}