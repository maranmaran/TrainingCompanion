using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.ExercisePropertyType.Update
{

    public class UpdateExercisePropertyTypeValidator : AbstractValidator<Domain.Entities.ExerciseType.ExercisePropertyType>
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

        private bool BeUniqueType(Domain.Entities.ExerciseType.ExercisePropertyType request)
        {
            return _context.ExercisePropertyTypes.FirstOrDefault(x => x.Id == request.Id) != null;
        }
    }
}
