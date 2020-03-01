using FluentValidation;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequestValidator : AbstractValidator<GetAllPersonalBestRequest>
    {
        public GetAllPersonalBestRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}