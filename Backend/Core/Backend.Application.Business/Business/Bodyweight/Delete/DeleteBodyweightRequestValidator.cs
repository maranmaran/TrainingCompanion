using FluentValidation;

namespace Backend.Application.Business.Business.Bodyweight.Delete
{
    public class DeleteBodyweightRequestValidator : AbstractValidator<DeleteBodyweightRequest>
    {
        public DeleteBodyweightRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}