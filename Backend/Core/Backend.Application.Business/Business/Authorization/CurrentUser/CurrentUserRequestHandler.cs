using AutoMapper;
using Backend.Application.Business.Business.Billing.GetPlans;
using Backend.Application.Business.Business.Billing.GetSubscription;
using Backend.Application.Business.Business.Billing.GetSubscriptionStatus;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.User;

namespace Backend.Application.Business.Business.Authorization.CurrentUser
{
    public class CurrentUserRequestHandler : IRequestHandler<CurrentUserRequest, CurrentUserRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CurrentUserRequestHandler(IMapper mapper, IPaymentService paymentService, IApplicationDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _paymentService = paymentService;
            _context = context;
            _mediator = mediator;
        }

        public async Task<CurrentUserRequestResponse> Handle(CurrentUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                                            .Include(x => x.UserSetting)
                                            .SingleAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

                if (user == null) throw new NotFoundException(nameof(ApplicationUser), request.UserId);

                var response = _mapper.Map<CurrentUserRequestResponse>(user);

                if (user.AccountType == AccountType.Coach || user.AccountType == AccountType.SoloAthlete)
                {
                    response.SubscriptionStatus = await _mediator.Send(new GetSubscriptionStatusRequest(response.CustomerId), cancellationToken);
                    response.SubscriptionInfo = await _mediator.Send(new GetSubscriptionRequest(response.CustomerId), cancellationToken);
                    response.Plans = await _mediator.Send(new GetPlansRequest(), cancellationToken);
                }

                return response;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(CurrentUser), request.UserId, e);
            }

        }
    }
}
