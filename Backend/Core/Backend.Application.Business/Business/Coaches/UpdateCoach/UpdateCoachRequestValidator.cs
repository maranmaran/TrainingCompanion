using FluentValidation;

namespace Backend.Application.Business.Business.Coaches.UpdateCoach
{
    public class UpdateCoachRequestValidator : AbstractValidator<UpdateCoachRequest>
    {
        public UpdateCoachRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);
        }
    }
}
