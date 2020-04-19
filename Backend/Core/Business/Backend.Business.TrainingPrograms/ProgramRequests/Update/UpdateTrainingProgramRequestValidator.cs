using Backend.Business.TrainingPrograms.TrainingBlockRequests.Update;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Update
{
    public class UpdateTrainingProgramRequestValidator : AbstractValidator<UpdateTrainingBlockRequest>
    {
        public UpdateTrainingProgramRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}