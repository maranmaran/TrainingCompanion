using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Business.Users.UsersRequests.CreateUser
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15)
                .Must(UniqueUsername)
                .WithMessage("Username must be unique"); ;

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .EmailAddress()
                .Must(UniqueEmail)
                .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15);
        }

        private bool UniqueUsername(CreateUserRequest request, string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username);
            return user == null; // no user with that username
        }

        private bool UniqueEmail(CreateUserRequest request, string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            return user == null; // no user with that email
        }
    }
}