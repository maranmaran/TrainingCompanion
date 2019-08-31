using Backend.Domain;
using FluentValidation;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Backend.Application.Business.Business.ExercisePropertyType.Create
{
    public class CreateExercisePropertyTypeValidator : AbstractValidator<CreateExercisePropertyTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        public CreateExercisePropertyTypeValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Type)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Type name must be unique"); ;
        }

        private bool BeUniqueType(CreateExercisePropertyTypeRequest request)
        {
            return _context.ExercisePropertyTypes.Where(x => x.ApplicationUserId == request.ApplicationUserId).FirstOrDefault(x => x.Type.Equals(request.Type)) != null;
        }
    }
}
