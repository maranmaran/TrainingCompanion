using AutoMapper;
using Backend.Application.Business.Business.Athletes.CreateAthlete;
using Backend.Application.Business.Business.Coaches.CreateCoach;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateUserRequestHandler(IMediator mediator, IMapper mapper, IApplicationDbContext context)
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

                        var newCoachRequest = _mapper.Map<CreateCoachRequest>(request);
                        return _mapper.Map<Athlete>(await _mediator.Send(newCoachRequest, cancellationToken));

                    case AccountType.Athlete:

                        var newAthleteRequest = _mapper.Map<CreateAthleteRequest>(request);
                        return _mapper.Map<Coach>(await _mediator.Send(newAthleteRequest, cancellationToken));

                    case AccountType.SoloAthlete:

                        return null;
                    default:
                        throw new Exception($"This account type does not exist: {request.AccountType}");
                }

            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ApplicationUser), e);
            }
        }
    }
}
