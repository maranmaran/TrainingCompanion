using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Infrastructure.Exceptions;
using Backend.Service.Payment.Interfaces;
using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Queries.GetPlans
{
    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, IEnumerable<Plan>>
    {
        private readonly IPaymentService _paymentService;

        public GetPlansQueryHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IEnumerable<Plan>> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentService.GetAvailablePlans();
            }
            catch (Exception e)
            {
                throw new NotFoundException("No plans were found. Something went wrong.", e);
            }
        }
    }
}
