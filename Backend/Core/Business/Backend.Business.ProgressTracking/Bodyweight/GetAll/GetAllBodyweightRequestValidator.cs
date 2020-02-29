using FluentValidation;

namespace Backend.Business.ProgressTracking.Bodyweight.GetAll
{
    public class GetAllBodyweightRequestValidator : AbstractValidator<GetAllBodyweightRequest>
    {
        public GetAllBodyweightRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}