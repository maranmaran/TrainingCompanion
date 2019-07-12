using System.Collections.Generic;
using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Queries.GetPlans
{
    public class GetPlansQuery : IRequest<IEnumerable<Plan>>
    {
    }
}
