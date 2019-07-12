using Backend.Service.Payment.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Billing.Commands.CancelSubscription
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand>
    {
        private readonly IPaymentService _paymentService;

        public CancelSubscriptionCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<Unit> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
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
