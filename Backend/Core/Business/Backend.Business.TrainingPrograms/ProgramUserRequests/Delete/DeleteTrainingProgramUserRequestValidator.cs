using FluentValidation;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Delete
{
    public class DeleteTrainingProgramUserRequestValidator : AbstractValidator<DeleteTrainingProgramUserRequest>
    {
        public DeleteTrainingProgramUserRequestValidator()
        {
            RuleFor(x => x.TrainingProgramUserId)
                .NotEmpty();
        }
    }
}