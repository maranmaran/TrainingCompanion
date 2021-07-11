using Backend.Infrastructure.Exceptions;
using Backend.Library.Payment.Interfaces;
using MediatR;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Billing.BillingRequests.GetSubscription
{
    public class GetSubscriptionRequestHandler : IRequestHandler<GetSubscriptionRequest, Subscription>
    {
        private readonly IPaymentService _paymentService;

        public GetSubscriptionRequestHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<Subscription> Handle(GetSubscriptionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetCustomerSubscription(request.CustomerId);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Subscription), $"Could not find any subscription for customer {request.CustomerId}", e);
            }
        }
    }
}