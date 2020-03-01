using FluentValidation;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Update
{
    public class UpdateBodyweightRequestValidator : AbstractValidator<UpdateBodyweightRequest>
    {
        public UpdateBodyweightRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}