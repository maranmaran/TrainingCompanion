using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Enums;
using Backend.Service.Payment.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Billing.GetSubscriptionStatus
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