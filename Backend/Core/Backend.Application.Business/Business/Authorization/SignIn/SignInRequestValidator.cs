using Backend.Domain;
using Backend.Service.Authorization.Interfaces;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.Authorization.SignIn
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public SignInRequestValidator(IApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;

            RuleFor(x => x)
                .Must(UserExists).WithMessage($"User does not exist")
                .Must(UserActive).WithMessage("This user is inactive");

            RuleFor(x => x.Username).MaximumLength(15).NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(4)
                .MaximumLength(15)
                .NotEmpty()
                .Must((request, password) => PasswordMatches(request))
                .WithMessage("Wrong password");
        }

        private bool UserExists(SignInRequest request)
        {
            return _context.Users.Any(x => x.Username == request.Username);

        }

        private bool UserActive(SignInRequest request)
        {
            return _context.Users.Where(x => x.Username == request.Username).Select(x => x.Active).Single();
        }

        private bool PasswordMatches(SignInRequest request)
        {
            var passwordHash = _context.Users.Where(x => x.Username == request.Username).Select(x => x.PasswordHash).Single();

            return passwordHash == _passwordHasher.GetPasswordHash(request.Password);
        }
    }
}
