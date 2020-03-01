using MediatR;
using Stripe;

namespace Backend.Business.Billing.BillingRequests.Subscribe
{
    public class SubscribeRequest : IRequest<Subscription>
    {
        public string CustomerId { get; set; }

        public string PlanId { get; set; }
    }
}