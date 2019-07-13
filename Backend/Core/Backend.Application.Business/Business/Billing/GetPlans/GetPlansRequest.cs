using System.Collections.Generic;
using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.GetPlans
{
    public class GetPlansRequest : IRequest<IEnumerable<Plan>>
    {
    }
}
