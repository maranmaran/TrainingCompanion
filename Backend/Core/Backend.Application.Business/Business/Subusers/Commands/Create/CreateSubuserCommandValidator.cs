using FluentValidation;

namespace Backend.Application.Business.Business.Subusers.Commands.Create
{
    public class CreateSubuserCommandValidator : AbstractValidator<CreateSubuserCommand>
    {
        public CreateSubuserCommandValidator()
        {
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);
        }
    }
}
