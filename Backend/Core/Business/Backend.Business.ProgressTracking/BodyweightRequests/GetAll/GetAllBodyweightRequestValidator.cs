using FluentValidation;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequestValidator : AbstractValidator<GetAllBodyweightRequest>
    {
        public GetAllBodyweightRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}