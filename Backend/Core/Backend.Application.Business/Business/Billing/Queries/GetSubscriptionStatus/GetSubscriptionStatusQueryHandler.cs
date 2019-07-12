using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Payment.Enums;
using Backend.Service.Payment.Interfaces;
using MediatR;

namespace Backend.Application.Business.Business.Billing.Queries.GetSubscriptionStatus
{
    public class GetSubscriptionStatusQueryHandler : IRequestHandler<GetSubscriptionStatusQuery, SubscriptionStatus>
    {
        private readonly IPaymentService _paymentService;

        public GetSubscriptionStatusQueryHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<SubscriptionStatus> Handle(GetSubscriptionStatusQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetCustomerSubscriptionStatus(request.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
