using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.Payment.Interfaces;
using MediatR;

namespace Backend.Business.Billing.BillingRequests.CancelSubscription
{
    public class CancelSubscriptionRequestHandler : IRequestHandler<CancelSubscriptionRequest>
    {
        private readonly IPaymentService _paymentService;

        public CancelSubscriptionRequestHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<Unit> Handle(CancelSubscriptionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _paymentService.CancelSubscription(request.SubscriptionId);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not cancel subscription. {request.SubscriptionId}", ex);
            }
        }
    }
}