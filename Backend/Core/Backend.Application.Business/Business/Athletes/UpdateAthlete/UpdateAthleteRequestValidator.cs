using FluentValidation;

namespace Backend.Application.Business.Business.Athletes.UpdateAthlete
{
    public class UpdateAthleteRequestValidator : AbstractValidator<UpdateAthleteRequest>
    {
        public UpdateAthleteRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);
        }
    }
}
