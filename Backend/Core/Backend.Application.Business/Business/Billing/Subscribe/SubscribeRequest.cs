using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Subscribe
{
    public class SubscribeRequest : IRequest<Subscription>
    {
        public string CustomerId { get; set; }

        public string PlanId { get; set; }
    }
}
