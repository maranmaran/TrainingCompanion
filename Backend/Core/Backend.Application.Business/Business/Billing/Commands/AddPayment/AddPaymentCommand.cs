using MediatR;
using Stripe;

namespace Backend.Application.Business.Business.Billing.Commands.AddPayment
{
    public class AddPaymentCommand : IRequest
    {
        public string CustomerId { get; set; }
        public string Token { get; set; }
    }
}
