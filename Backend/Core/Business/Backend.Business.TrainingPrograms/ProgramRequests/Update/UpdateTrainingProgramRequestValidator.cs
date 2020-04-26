using Backend.Business.TrainingPrograms.BlockRequests.Update;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Update
{
    public class UpdateTrainingProgramRequestValidator : AbstractValidator<UpdateTrainingBlockRequest>
    {
        public UpdateTrainingProgramRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}