using System.Linq;
using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.ExerciseProperty.Update
{
    public class UpdateExercisePropertyRequestValidator : AbstractValidator<UpdateExercisePropertyRequest>
    {
        private readonly IApplicationDbContext _context;
        public UpdateExercisePropertyRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Value)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Property name must be unique"); ;
        }

        private bool BeUniqueType(UpdateExercisePropertyRequest request)
        {
            var property = _context.ExerciseProperties
                .Single(x => x.Id == request.Id);

            return _context.ExercisePropertyTypes.Include(x => x.Properties).Single(x => x.Id == property.ExercisePropertyTypeId).Properties.All(x => x.Value != request.Value);
        }
    }
}