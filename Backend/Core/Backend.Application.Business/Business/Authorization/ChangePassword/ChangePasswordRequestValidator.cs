using FluentValidation;
using System;

namespace Backend.Application.Business.Business.Authorization.ChangePassword
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