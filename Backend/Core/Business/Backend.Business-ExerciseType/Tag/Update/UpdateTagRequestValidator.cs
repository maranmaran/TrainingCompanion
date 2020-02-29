using System.Linq;
using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business_ExerciseType.Tag.Update
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
            var tag = _context.Tags
                .Single(x => x.Id == request.Id);

            return _context.TagGroups.Include(x => x.Tags).Single(x => x.Id == tag.TagGroupId).Tags.All(x => x.Value != request.Value);
        }
    }
}