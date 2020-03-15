using System.Linq;
using Backend.Domain;
using FluentValidation;

namespace Backend.Business.Exercises.TagGroupRequests.Create
{
    public class CreateTagGroupValidator : AbstractValidator<CreateTagGroupRequest>
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

        private bool BeUniqueType(CreateTagGroupRequest request)
        {
            return _context.TagGroups.Where(x => x.ApplicationUserId == request.ApplicationUserId).FirstOrDefault(x => x.Type.Equals(request.Type)) == null;
        }
    }
}