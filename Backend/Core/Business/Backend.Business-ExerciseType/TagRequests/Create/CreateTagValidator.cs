using System.Linq;
using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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
            return _context.TagGroups.Include(x => x.Tags).Single(x => x.Id == request.TagGroupId).Tags.All(x => x.Value != request.Value);
        }
    }
}