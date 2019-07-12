using System;
using Backend.Domain.Enum;
using Backend.Service.Payment.Enums;
using Stripe;
using AccountType = Backend.Domain.Enum.AccountType;

namespace Backend.Application.Business.Business.Authorization.Commands.SignIn
{
    public class SignInResponse
    {
        public SignInResponse()
        {

        }

        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public Subscription SubscriptionInfo { get; set; }
        public int TrialDaysRemaining { get; set; }
    }
}
