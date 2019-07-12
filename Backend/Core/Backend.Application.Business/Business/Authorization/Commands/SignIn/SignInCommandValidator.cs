using FluentValidation;

namespace Backend.Application.Business.Business.Authorization.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(4).MaximumLength(15).NotEmpty();
        }
    }
}
