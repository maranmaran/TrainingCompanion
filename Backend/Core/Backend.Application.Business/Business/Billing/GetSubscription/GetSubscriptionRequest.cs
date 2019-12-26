using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.GetSubscription
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