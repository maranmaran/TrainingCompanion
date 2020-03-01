using System;
using FluentValidation;

namespace Backend.Business.Authorization.AuthorizationRequests.ChangePassword
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
        }
    }
}