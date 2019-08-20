using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.Users.UpdateUser
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
                .Must((user, username) => UniqueUsername(username))
                .WithMessage("Username must be unique"); ;

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .Must((user, email) => UniqueEmail(email))
                .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName).MaximumLength(15).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(15).NotEmpty();
        }

        private bool UniqueUsername(string username)
        {
            return !_context.Users.Any(x => x.Username == username);
        }

        private bool UniqueEmail(string email)
        {
            return !_context.Users.Any(x => x.Email == email);
        }

    }
}
