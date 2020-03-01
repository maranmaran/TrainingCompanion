using FluentValidation;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Create
{
    public class CreatePersonalBestRequestValidator : AbstractValidator<CreatePersonalBestRequest>
    {
        public CreatePersonalBestRequestValidator()
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}