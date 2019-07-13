using FluentValidation;

namespace Backend.Application.Business.Business.Subusers.CreateSubuser
{
    public class CreateSubuserRequestValidator : AbstractValidator<CreateSubuserRequest>
    {
        public CreateSubuserRequestValidator()
        {
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);
        }
    }
}
