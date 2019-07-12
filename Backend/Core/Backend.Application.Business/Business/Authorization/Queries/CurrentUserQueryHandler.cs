using AutoMapper;
using Backend.Application.Business.Business.Billing.Queries.GetPlans;
using Backend.Application.Business.Business.Billing.Queries.GetSubscription;
using Backend.Application.Business.Business.Billing.Queries.GetSubscriptionStatus;
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

namespace Backend.Application.Business.Business.Authorization.Queries
{
    public class CurrentUserQueryHandler : IRequestHandler<CurrentUserQuery, CurrentUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CurrentUserQueryHandler(IMapper mapper, IPaymentService paymentService, IApplicationDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _paymentService = paymentService;
            _context = context;
            _mediator = mediator;
        }

        public async Task<CurrentUserQueryResponse> Handle(CurrentUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                                            .Include(x => x.UserSettings)
                                            .SingleAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

                if (user == null) throw new NotFoundException(nameof(ApplicationUser), request);

                var response = _mapper.Map<CurrentUserQueryResponse>(user);

                if (user.AccountType == AccountType.User)
                {
                    response.SubscriptionStatus = await _mediator.Send(new GetSubscriptionStatusQuery(response.CustomerId), cancellationToken);
                    response.SubscriptionInfo = await _mediator.Send(new GetSubscriptionQuery(response.CustomerId), cancellationToken);
                    response.Plans = await _mediator.Send(new GetPlansQuery(), cancellationToken);
                }

                return response;
            }
            catch (Exception e)
            {
                throw new NotFoundException("Could not find current user.", e);
            }

        }
    }
}
