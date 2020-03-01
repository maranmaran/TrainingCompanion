using FluentValidation;

namespace Backend.Business.Billing.BillingRequests.AddPayment
{
    public class AddPaymentRequestValidator : AbstractValidator<AddPaymentRequest>
    {
        public AddPaymentRequestValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}