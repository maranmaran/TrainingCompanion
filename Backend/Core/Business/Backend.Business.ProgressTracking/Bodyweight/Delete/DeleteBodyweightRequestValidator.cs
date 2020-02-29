using FluentValidation;

namespace Backend.Business.ProgressTracking.Bodyweight.Delete
{
    public class DeleteBodyweightRequestValidator : AbstractValidator<DeleteBodyweightRequest>
    {
        public DeleteBodyweightRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}