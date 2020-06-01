using FluentValidation;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.GetAll
{
    public class GetAllTrainingProgramUsersRequestValidator : AbstractValidator<GetAllTrainingProgramUsersRequest>
    {
        public GetAllTrainingProgramUsersRequestValidator()
        {
            RuleFor(x => x.ProgramId)
                .NotEmpty();
        }
    }
}