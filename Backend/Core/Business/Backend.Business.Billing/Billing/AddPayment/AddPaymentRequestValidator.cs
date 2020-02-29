using FluentValidation;

namespace Backend.Business.Billing.Billing.AddPayment
{
    public class AddPaymentRequestValidator : AbstractValidator<AddPaymentRequest>
    {
        public AddPaymentRequestValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}