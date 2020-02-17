using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.TagGroup.Create
{
    public class CreateTagGroupValidator : AbstractValidator<Domain.Entities.ExerciseType.TagGroup>
    {
        private readonly IApplicationDbContext _context;

        public CreateTagGroupValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Type)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Type name must be unique"); ;
        }

        private bool BeUniqueType(Domain.Entities.ExerciseType.TagGroup request)
        {
            return _context.TagGroups.Where(x => x.ApplicationUserId == request.ApplicationUserId).FirstOrDefault(x => x.Type.Equals(request.Type)) == null;
        }
    }
}