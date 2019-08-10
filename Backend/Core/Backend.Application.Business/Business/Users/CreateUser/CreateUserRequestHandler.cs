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
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserRequestResponse>
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

        public async Task<CreateUserRequestResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Validate(request);

                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        var newCoachRequest = _mapper.Map<CreateCoachRequest>(request);
                        return _mapper.Map<CreateUserRequestResponse>(await _mediator.Send(newCoachRequest, cancellationToken));

                    case AccountType.Athlete:

                        var newAthleteRequest = _mapper.Map<CreateAthleteRequest>(request);
                        return _mapper.Map<CreateUserRequestResponse>(await _mediator.Send(newAthleteRequest, cancellationToken));

                    case AccountType.SoloAthlete:

                        return null;
                    default:
                        throw new Exception($"This account type does not exist: {request.AccountType}");
                }

            }
            catch (Exception e)
            {
                if (e is ExtendedException exception)
                {
                    throw exception;
                }

                throw new CreateFailureException(nameof(ApplicationUser), e);
            }
        }

        private void Validate(CreateUserRequest request)
        {
            if (_context.Users.Any(x => x.Username == request.Username))
            {
                throw new ExtendedException((int)CreateUserValidationStatusCodes.UsernameExists, "This username is already taken.");
            }
            if (_context.Users.Any(x => x.Email == request.Email))
            {
                throw new ExtendedException((int)CreateUserValidationStatusCodes.EmailExists, "This email is already taken.");
            }
        }
    }
}
