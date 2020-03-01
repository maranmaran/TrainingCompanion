using System.Linq;
using Backend.Domain;
using FluentValidation;

namespace Backend.Business.Users.UsersRequests.UpdateUser
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Username)
                .MaximumLength(15)
                .NotEmpty()
                .Must((request, username) => UniqueUsername(request))
                .WithMessage("Username must be unique"); ;

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .Must((request, email) => UniqueEmail(request))
                .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName).MaximumLength(15).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(15);
        }

        private bool UniqueUsername(UpdateUserRequest request)
        {
            var user = _context.Users.Single(x => x.Id == request.Id);
            return !_context.Users.Any(x => x.Username == user.Username && x.Id != user.Id);
        }

        private bool UniqueEmail(UpdateUserRequest request)
        {
            var user = _context.Users.Single(x => x.Id == request.Id);
            return !_context.Users.Any(x => x.Email == user.Email && x.Id != user.Id);
        }
    }
}