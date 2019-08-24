using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.ExercisePropertyType.Update
{

    public class UpdateExercisePropertyTypeValidator : AbstractValidator<UpdateExercisePropertyTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        public UpdateExercisePropertyTypeValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Type)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Type name must be unique"); ;
        }

        private bool BeUniqueType(UpdateExercisePropertyTypeRequest request)
        {
            var propertyType = _context.ExercisePropertyTypes
                .Single(x => x.Id == request.Id);

            return !_context.ExercisePropertyTypes.Where(x => x.ApplicationUserId == propertyType.ApplicationUserId)
                .Any(x => x.Type == request.Type);
        }
    }
}
