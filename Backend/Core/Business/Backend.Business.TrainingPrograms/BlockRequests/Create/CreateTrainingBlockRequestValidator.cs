using Backend.Domain.Entities.TrainingProgramMaker;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.BlockRequests.Create
{
    public class CreateTrainingBlockRequestValidator : AbstractValidator<TrainingBlock>
    {
        public CreateTrainingBlockRequestValidator()
        {
            RuleFor(x => x.TrainingProgramId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}