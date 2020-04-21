using Backend.Domain.Entities.TrainingProgramMaker;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.ProgramRequests.Create
{
    public class CreateTrainingProgramRequestValidator : AbstractValidator<TrainingProgram>
    {
        public CreateTrainingProgramRequestValidator()
        {
            RuleFor(x => x.CreatorId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}