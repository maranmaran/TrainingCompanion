using FluentValidation;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Update
{
    public class UpdatePersonalBestRequestValidator : AbstractValidator<UpdatePersonalBestRequest>
    {
        public UpdatePersonalBestRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}