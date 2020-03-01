using FluentValidation;

namespace Backend.Business.ProgressTracking.BodyweightRequests.Delete
{
    public class DeleteBodyweightRequestValidator : AbstractValidator<DeleteBodyweightRequest>
    {
        public DeleteBodyweightRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}