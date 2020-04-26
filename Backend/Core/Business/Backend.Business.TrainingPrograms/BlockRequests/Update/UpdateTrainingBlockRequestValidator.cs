using FluentValidation;

namespace Backend.Business.TrainingPrograms.BlockRequests.Update
{
    public class UpdateTrainingBlockRequestValidator : AbstractValidator<UpdateTrainingBlockRequest>
    {
        public UpdateTrainingBlockRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}