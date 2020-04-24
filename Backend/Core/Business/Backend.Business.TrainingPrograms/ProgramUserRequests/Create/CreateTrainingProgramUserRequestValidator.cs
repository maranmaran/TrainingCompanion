using FluentValidation;
using System;

namespace Backend.Business.TrainingPrograms.ProgramUserRequests.Create
{
    public class CreateTrainingProgramUserRequestValidator : AbstractValidator<CreateTrainingProgramUserRequest>
    {
        public CreateTrainingProgramUserRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProgramId).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty().Must(date => date.ToUniversalTime().Date >= DateTime.UtcNow.Date);
        }
    }
}