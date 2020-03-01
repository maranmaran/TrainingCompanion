using MediatR;

namespace Backend.Business.Billing.BillingRequests.AddPayment
{
    public class AddPaymentRequest : IRequest
    {
        public string CustomerId { get; set; }
        public string Token { get; set; }
    }
}