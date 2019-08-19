using Backend.Domain.Entities;
using Backend.Service.Payment.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using Backend.Domain.Entities.User;
using AccountType = Backend.Domain.Enum.AccountType;

namespace Backend.Application.Business.Business.Authorization.CurrentUser
{
    public class CurrentUserRequestResponse
    {
        // basic account info
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }


        public AccountType AccountType { get; set; }
        public bool Active { get; set; }
        public UserSettings UserSettings { get; set; }


        // Billing
        public int TrialDaysRemaining { get; set; }
        public string CustomerId { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public Subscription SubscriptionInfo { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
    }
}
