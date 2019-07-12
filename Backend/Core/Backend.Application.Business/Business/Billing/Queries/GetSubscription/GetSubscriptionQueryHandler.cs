using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Queries.GetSubscription
{
    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, Subscription>
    {
        private readonly IPaymentService _paymentService;

        public GetSubscriptionQueryHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        public async Task<Subscription> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetCustomerSubscription(request.CustomerId);
            }
            catch (Exception e)
            {
                throw new NotFoundException($"Could not find any subscription for customer {request.CustomerId}", e);
            }
        }
    }
}
