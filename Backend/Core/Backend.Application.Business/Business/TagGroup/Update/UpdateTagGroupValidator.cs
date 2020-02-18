using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.TagGroup.Update
{
    public class UpdateTagGroupValidator : AbstractValidator<UpdateTagGroupRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTagGroupValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.TagGroup.Type)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request.TagGroup))
                .WithMessage("Type name must be unique"); ;
        }

        private bool BeUniqueType(Domain.Entities.ExerciseType.TagGroup request)
        {
            return !_context.TagGroups.Any(x => x.Id != request.Id && x.Type == request.Type);
        }
    }
}