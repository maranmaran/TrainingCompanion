using FluentValidation;

namespace Backend.Business.ProgressTracking.Bodyweight.Create
{
    public class CreateBodyweightRequestValidator : AbstractValidator<CreateBodyweightRequest>
    {
        public CreateBodyweightRequestValidator()
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}