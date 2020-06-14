using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Business.Exercises.TagRequests.Create
{
    public class CreateTagValidator : AbstractValidator<CreateTagRequest>
    {
        private readonly IApplicationDbContext _context;

        public CreateTagValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Value)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Property name must be unique"); ;
        }

        private bool BeUniqueType(CreateTagRequest request)
        {
            var tagGroup = _context.TagGroups.Include(x => x.Tags).FirstOrDefault(x => x.Id == request.TagGroupId);

            if (tagGroup == null)
                return false;

            var sameValueTag = tagGroup.Tags.FirstOrDefault(x => x.Value == request.Value);

            return sameValueTag == null; // Same value must not exist in order for tag to be unique
        }
    }
}