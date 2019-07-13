using MediatR;

namespace Backend.Application.Business.Business.Billing.CancelSubscription
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
