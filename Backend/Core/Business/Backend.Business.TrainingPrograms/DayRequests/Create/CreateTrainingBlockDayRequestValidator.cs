using Backend.Domain.Entities.TrainingProgramMaker;
using FluentValidation;

namespace Backend.Business.TrainingPrograms.DayRequests.Create
{
    public class CreateTrainingBlockDayRequestValidator : AbstractValidator<TrainingBlockDay>
    {
        public CreateTrainingBlockDayRequestValidator()
        {

        }
    }
}