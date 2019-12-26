using MediatR;
using Stripe;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.Billing.GetPlans
{
    public class GetPlansRequest : IRequest<IEnumerable<Plan>>
    {
    }
}