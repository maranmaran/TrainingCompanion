using FluentValidation;
using System;

namespace Backend.Business.Authorization.AuthorizationRequests.ChangePassword
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(15);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(" ")
                .Equal(x => x.ConfirmPassword)
                .MinimumLength(4);
        }
    }
}