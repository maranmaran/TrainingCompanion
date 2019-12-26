using FluentValidation;

namespace Backend.Application.Business.Business.Billing.AddPayment
{
    public class AddPaymentRequestValidator : AbstractValidator<AddPaymentRequest>
    {
        public AddPaymentRequestValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}