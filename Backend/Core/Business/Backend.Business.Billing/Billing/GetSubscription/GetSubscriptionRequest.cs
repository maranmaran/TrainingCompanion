using MediatR;
using Stripe;

namespace Backend.Business.Billing.Billing.GetSubscription
{
    public class GetSubscriptionRequest : IRequest<Subscription>
    {
        public string CustomerId { get; set; }

        public GetSubscriptionRequest()
        {
        }

        public GetSubscriptionRequest(string customerId)
        {
            CustomerId = customerId;
        }
    }
}