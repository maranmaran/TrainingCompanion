using FluentValidation;

namespace Backend.Application.Business.Business.Bodyweight.GetAll
{
    public class GetAllBodyweightRequestValidator : AbstractValidator<GetAllBodyweightRequest>
    {
        public GetAllBodyweightRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}