using Backend.Service.Payment.Enums;
using MediatR;

namespace Backend.Application.Business.Business.Billing.Queries.GetSubscriptionStatus
{
    public class GetSubscriptionStatusQuery: IRequest<SubscriptionStatus>
    {
        public string Id { get; set; }

        public GetSubscriptionStatusQuery()
        {
            
        }

        public GetSubscriptionStatusQuery(string id)
        {
            Id = id;
        }
    }
}
