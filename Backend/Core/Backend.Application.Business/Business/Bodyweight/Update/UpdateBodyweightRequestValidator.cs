using FluentValidation;

namespace Backend.Application.Business.Business.Bodyweight.Update
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