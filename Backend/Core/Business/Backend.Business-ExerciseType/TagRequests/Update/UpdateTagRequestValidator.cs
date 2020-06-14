using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Business.Exercises.TagRequests.Update
{
    public class UpdateTagRequestValidator : AbstractValidator<UpdateTagRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTagRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Value)
                .MaximumLength(30)
                .NotEmpty()
                .Must((request, type) => BeUniqueType(request))
                .WithMessage("Tag value must be unique"); ;
        }

        private bool BeUniqueType(UpdateTagRequest request)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == request.Id);

            if (tag == null)
                return false;

            // find all tags except the one that's updating.. that belong to his parent (tag group)
            var allOtherTags = _context.Tags.Where(x => x.TagGroupId == tag.TagGroupId && x.Id != tag.Id);

            // same value tag must be null in order for updating tag to bear unique value
            var sameValueTag = allOtherTags.FirstOrDefault(x => x.Value == tag.Value);

            return sameValueTag == null;
        }
    }
}