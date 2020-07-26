using Backend.Business.Authorization.Utils;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Library.Payment.Enums;
using Backend.Library.Payment.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Business.Authorization.AuthorizationRequests.SignIn
{
    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPaymentService _paymentService;

        public SignInRequestValidator(IApplicationDbContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty();

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(x => x)
                .Must(BeValidUser).WithMessage($"VALIDATION.USER_NOT_VALID");
        }

        private bool BeValidUser(SignInRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username);

            // user must exist
            if (user == null)
                return false;

            // user must be active
            if (user.Active == false)
                return false;

            // user password and request password must match
            var requestPasswordHash = PasswordHasher.GetPasswordHash(request.Password);
            if (user.PasswordHash != requestPasswordHash)
                return false;

            // user must have active payment or be in trial
            var customerId = user.CustomerId;

            // for athletes.. coach is responsible for subscription
            if (user.AccountType == AccountType.Athlete)
            {
                var athlete = _context.Athletes.Include(x => x.Coach).First(x => x.Id == user.Id);
                customerId = athlete.Coach.CustomerId;
            }

            var paymentInfo = _paymentService.GetCustomerSubscriptionStatus(customerId).Result;

            return paymentInfo == SubscriptionStatus.Active || paymentInfo == SubscriptionStatus.Trialing;
        }
    }
}