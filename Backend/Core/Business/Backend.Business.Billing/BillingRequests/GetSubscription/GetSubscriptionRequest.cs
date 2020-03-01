using MediatR;
using Stripe;

namespace Backend.Business.Billing.BillingRequests.GetSubscription
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