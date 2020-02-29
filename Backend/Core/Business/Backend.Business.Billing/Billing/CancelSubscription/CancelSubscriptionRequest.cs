using MediatR;

namespace Backend.Business.Billing.Billing.CancelSubscription
{
    public class CancelSubscriptionRequest : IRequest
    {
        public string SubscriptionId { get; set; }

        public CancelSubscriptionRequest()
        {
        }

        public CancelSubscriptionRequest(string subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}