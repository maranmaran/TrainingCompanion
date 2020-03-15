using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.Payment.Enums;
using Backend.Library.Payment.Interfaces;
using Backend.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.Billing.BillingRequests.GetSubscriptionStatus
{
    public class GetSubscriptionStatusRequestHandler : IRequestHandler<GetSubscriptionStatusRequest, SubscriptionStatus>
    {
        private readonly IPaymentService _paymentService;

        public GetSubscriptionStatusRequestHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<SubscriptionStatus> Handle(GetSubscriptionStatusRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetCustomerSubscriptionStatus(request.Id);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(SubscriptionStatus), e);
            }
        }
    }
}