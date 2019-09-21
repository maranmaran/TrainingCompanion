using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Application.Business.Business.Tag.Update
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
            var tag = _context.ExerciseProperties
                .Single(x => x.Id == request.Id);

            return _context.TagGroups.Include(x => x.Properties).Single(x => x.Id == tag.TagGroupId).Properties.All(x => x.Value != request.Value);
        }
    }
}