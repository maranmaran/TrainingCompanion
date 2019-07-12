using System;
using System.Collections.Generic;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Payment.Enums;
using Stripe;
using AccountType = Backend.Domain.Enum.AccountType;

namespace Backend.Application.Business.Business.Authorization.Queries
{
    public class CurrentUserQueryResponse
    {
        // basic accoutn info
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }


        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public UserSettings UserSettings { get; set; }


        // Billing
        public int TrialDaysRemaining { get; set; }
        public string CustomerId { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public Subscription SubscriptionInfo { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
    }
}
