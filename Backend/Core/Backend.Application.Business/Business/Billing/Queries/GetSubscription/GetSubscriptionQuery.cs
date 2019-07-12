using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Queries.GetSubscription
{
    public class GetSubscriptionQuery : IRequest<Subscription>
    {
        public string CustomerId { get; set; }

        public GetSubscriptionQuery()
        {

        }

        public GetSubscriptionQuery(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
