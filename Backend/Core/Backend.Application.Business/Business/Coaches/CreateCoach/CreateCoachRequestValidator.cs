
using FluentValidation;

namespace Backend.Application.Business.Business.Coaches.CreateCoach
{
    public class CreateCoachRequestValidator : AbstractValidator<CreateCoachRequest>
    {
        public CreateCoachRequestValidator()
        {
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
        }
    }
}
