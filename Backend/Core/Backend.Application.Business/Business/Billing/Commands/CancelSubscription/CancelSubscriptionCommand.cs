using MediatR;

namespace Backend.Application.Business.Business.Billing.Commands.CancelSubscription
{
    public class CancelSubscriptionCommand : IRequest
    {
        public string SubscriptionId { get; set; }

        public CancelSubscriptionCommand()
        {

        }

        public CancelSubscriptionCommand(string subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
