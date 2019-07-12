using System;
using FluentValidation;

namespace Backend.Application.Business.Business.Authorization.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator: AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
        }
    }
}
