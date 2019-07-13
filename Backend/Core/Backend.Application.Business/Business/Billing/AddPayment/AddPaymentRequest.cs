using MediatR;

namespace Backend.Application.Business.Business.Billing.AddPayment
{
    public class AddPaymentRequest : IRequest
    {
        public string CustomerId { get; set; }
        public string Token { get; set; }
    }
}
