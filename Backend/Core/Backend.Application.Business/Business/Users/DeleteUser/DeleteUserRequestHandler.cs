using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.Athletes.CreateAthlete;
using Backend.Application.Business.Business.Athletes.DeleteAthlete;
using Backend.Application.Business.Business.Coaches.CreateCoach;
using Backend.Application.Business.Business.Coaches.DeleteCoach;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Users.DeleteUser
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteUserRequestHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        var deleteCoachRequest = _mapper.Map<DeleteCoachRequest>(request);
                        await _mediator.Send(deleteCoachRequest, cancellationToken);
                        break;

                    case AccountType.Athlete:

                        var deleteAthleteRequest = _mapper.Map<DeleteAthleteRequest>(request);
                        await _mediator.Send(deleteAthleteRequest, cancellationToken);
                        break;

                    case AccountType.SoloAthlete:
                        break;

                    default:
                        throw new Exception($"This account type does not exist: {request.AccountType}");
                }

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ApplicationUser), request.Id, e.Message);
            }
        }
    }
}
