using FluentValidation;

namespace Backend.Application.Business.Business.Authorization.SignIn
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(4).MaximumLength(15).NotEmpty();
        }
    }
}
