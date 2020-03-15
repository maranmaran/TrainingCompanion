using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using FluentValidation;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Update
{
    public class UpdateExerciseTypeValidator : AbstractValidator<ExerciseType>
    {
        private readonly IApplicationDbContext _context;

        public UpdateExerciseTypeValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .MaximumLength(30)
                .NotEmpty();
        }
    }
}