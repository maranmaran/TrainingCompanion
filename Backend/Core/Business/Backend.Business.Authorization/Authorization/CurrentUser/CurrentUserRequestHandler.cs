using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.Billing.Billing.GetPlans;
using Backend.Business.Billing.Billing.GetSubscription;
using Backend.Business.Billing.Billing.GetSubscriptionStatus;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Authorization.Authorization.CurrentUser
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
                                            .ThenInclude(x => x.NotificationSettings)
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