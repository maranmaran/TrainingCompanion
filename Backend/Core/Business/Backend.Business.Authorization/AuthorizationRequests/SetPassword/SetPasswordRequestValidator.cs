using FluentValidation;
using System;

namespace Backend.Business.Authorization.AuthorizationRequests.SetPassword
{
    public class SetPasswordRequestValidator : AbstractValidator<SetPasswordRequest>
    {
        public SetPasswordRequestValidator()
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.RepeatPassword)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .NotEqual(" ")
                .Equal(x => x.RepeatPassword)
                .MinimumLength(4);
        }
    }
}