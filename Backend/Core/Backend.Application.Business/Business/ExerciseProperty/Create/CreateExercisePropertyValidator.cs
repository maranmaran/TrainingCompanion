using System.Linq;
using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseProperty.Create
{
    public class CreateExercisePropertyValidator : AbstractValidator<CreateExercisePropertyRequest>
    {
        private readonly IApplicationDbContext _context;
        public CreateExercisePropertyValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Value)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Property name must be unique"); ;
        }

        private bool BeUniqueType(CreateExercisePropertyRequest request)
        {
            return _context.ExercisePropertyTypes.Include(x => x.Properties).Single(x => x.Id == request.ExercisePropertyTypeId).Properties.All(x => x.Value != request.Value);
        }
    }
}
