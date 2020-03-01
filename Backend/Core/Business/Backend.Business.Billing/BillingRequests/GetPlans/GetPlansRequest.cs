using System.Collections.Generic;
using MediatR;
using Stripe;

namespace Backend.Business.Billing.BillingRequests.GetPlans
{
    public class GetPlansRequest : IRequest<IEnumerable<Plan>>
    {
    }
}