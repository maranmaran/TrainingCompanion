using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Commands.Subscribe
{
    public class SubscribeCommand : IRequest<Subscription>
    {
        public string CustomerId { get; set; }

        public string PlanId { get; set; }
    }
}
