using FluentValidation;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.Delete
{
    public class DeletePersonalBestRequestValidator : AbstractValidator<DeletePersonalBestRequest>
    {
        public DeletePersonalBestRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}