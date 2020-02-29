using FluentValidation;

namespace Backend.Business.Authorization.Authorization.SetPassword
{
    public class SetPasswordRequestValidator : AbstractValidator<SetPasswordRequest>
    {
        public SetPasswordRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(4)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.RepeatPassword).Matches(x => x.Password);
        }
    }
}