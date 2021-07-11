using MediatR;
using Stripe;
using System.Collections.Generic;

namespace Backend.Business.Billing.BillingRequests.GetPlans
{
    public class GetPlansRequest : IRequest<IEnumerable<Plan>>
    {
    }
}