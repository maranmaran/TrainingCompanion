using Backend.Domain;
using FluentValidation;
using System.Linq;

namespace Backend.Application.Business.Business.Athletes.CreateAthlete
{
    public class CreateAthleteRequestValidator : AbstractValidator<CreateAthleteRequest>
    {
        private readonly IApplicationDbContext _context;

        public CreateAthleteRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Username)
                .MaximumLength(15)
                .NotEmpty()
                .Must((athlete, username) => UniqueUsername(username))
                .WithMessage("Username must be unique"); ;

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .Must((athlete, email) => UniqueEmail(email))
                .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName).MaximumLength(15);
            RuleFor(x => x.LastName).MaximumLength(15);
        }

        private bool UniqueUsername(string username)
        {
            return !_context.Athletes.Any(x => x.Username == username);
        }

        private bool UniqueEmail(string email)
        {
            return !_context.Athletes.Any(x => x.Email == email);
        }
    }


}
