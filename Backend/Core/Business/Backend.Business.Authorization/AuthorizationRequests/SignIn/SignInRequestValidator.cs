using Backend.Business.Authorization.Utils;
using Backend.Domain;
using Backend.Library.Payment.Enums;
using Backend.Library.Payment.Interfaces;
using FluentValidation;
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
            var paymentInfo = _paymentService.GetCustomerSubscriptionStatus(user.CustomerId).Result;
            if (!(paymentInfo == SubscriptionStatus.Active || paymentInfo == SubscriptionStatus.Trialing))
                return false;

            // everything is valid
            return true;
        }
    }
}