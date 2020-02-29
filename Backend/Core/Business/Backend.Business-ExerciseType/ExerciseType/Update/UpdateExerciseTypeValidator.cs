using Backend.Domain;
using FluentValidation;

namespace Backend.Business_ExerciseType.ExerciseType.Update
{
    public class UpdateExerciseTypeValidator : AbstractValidator<Domain.Entities.ExerciseType.ExerciseType>
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