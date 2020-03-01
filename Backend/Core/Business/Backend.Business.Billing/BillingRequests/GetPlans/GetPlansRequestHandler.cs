using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Stripe;

namespace Backend.Business.Billing.BillingRequests.GetPlans
{
    public class GetPlansRequestHandler : IRequestHandler<GetPlansRequest, IEnumerable<Plan>>
    {
        private readonly IPaymentService _paymentService;

        public GetPlansRequestHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IEnumerable<Plan>> Handle(GetPlansRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetAvailablePlans();
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Plan), "No plans were found. Something went wrong.", e);
            }
        }
    }
}