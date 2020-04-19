using FluentValidation;

namespace Backend.Business.TrainingPrograms.TrainingBlockRequests.Update
{
    public class UpdateTrainingBlockRequestValidator : AbstractValidator<UpdateTrainingBlockRequest>
    {
        public UpdateTrainingBlockRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}