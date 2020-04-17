using FluentValidation;

namespace Backend.Business.TrainingPrograms.TrainingProgramRequests.Update
{
    public class UpdateTrainingProgramRequestValidator : AbstractValidator<UpdateTrainingProgramRequest>
    {
        public UpdateTrainingProgramRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}