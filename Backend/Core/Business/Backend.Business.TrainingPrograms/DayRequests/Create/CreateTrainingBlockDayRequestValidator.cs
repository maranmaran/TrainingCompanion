using Backend.Domain.Entities.TrainingProgramMaker;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Create
{
    public class CreateTrainingBlockDayRequestValidator : AbstractValidator<TrainingBlockDay>
    {
        public CreateTrainingBlockDayRequestValidator()
        {

        }
    }
}