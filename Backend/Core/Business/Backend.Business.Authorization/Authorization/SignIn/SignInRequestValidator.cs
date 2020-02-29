using System.Linq;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Utils;
using Backend.Service.Payment.Enums;
using Backend.Service.Payment.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Authorization.Authorization.SignIn
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPaymentService _paymentService;

        public SignInRequestValidator(IApplicationDbContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;

            RuleFor(x => x)
                .Must(UserExists).WithMessage($"ApplicationUser does not exist")
                .Must(UserActive).WithMessage("This user is inactive")
                .Must(CoachHasPaidSubscriptionIfUserIsAthlete).WithMessage("Coach did not renew his subscription");

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

            return passwordHash == PasswordHasher.GetPasswordHash(request.Password);
        }

        private bool CoachHasPaidSubscriptionIfUserIsAthlete(SignInRequest request)
        {
            var user = _context.Users.Single(x => x.Username == request.Username);

            if (user.AccountType != AccountType.Athlete) return true;

            var athlete = _context.Athletes.Include(x => x.Coach).Single(x => x.Id == user.Id);

            var coachPaymentInfo =
                _paymentService.GetCustomerSubscriptionStatus(athlete.Coach.CustomerId).Result;

            return coachPaymentInfo == SubscriptionStatus.Active || coachPaymentInfo == SubscriptionStatus.Trialing;
        }
    }
}