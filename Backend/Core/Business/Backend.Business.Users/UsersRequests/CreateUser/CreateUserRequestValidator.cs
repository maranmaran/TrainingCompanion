using System.Linq;
using Backend.Domain;
using FluentValidation;

namespace Backend.Business.Users.UsersRequests.CreateUser
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserRequestValidator(IApplicationDbContext context)
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