using FluentValidation;

namespace Backend.Application.Business.Business.Authorization.SetPassword
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