using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.Athletes.CreateAthlete;
using Backend.Application.Business.Business.Coaches.CreateCoach;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Domain.Extensions;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;

namespace Backend.Application.Business.Business.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserRequestResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateUserRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CreateUserRequestResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
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
                throw new CreateFailureException(nameof(ApplicationUser), e.Message);
            }
        }
    }
}
