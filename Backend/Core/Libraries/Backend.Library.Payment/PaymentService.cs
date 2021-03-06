﻿using Backend.Library.Payment.Enums;
using Backend.Library.Payment.Interfaces;
using Backend.Library.Payment.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService = Stripe.CustomerService;
using Plan = Stripe.Plan;
using PlanService = Stripe.PlanService;
using StripeConfiguration = Backend.Library.Payment.Configuration.StripeConfiguration;

namespace Backend.Library.Payment
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
        }

        public async Task AddPaymentOption(PaymentOption paymentOption)
        {
            // update token - card
            var customerService = new CustomerService();
            await customerService.UpdateAsync(paymentOption.CustomerId, new CustomerUpdateOptions()
            {
                Source = paymentOption.Token
            });
        }

        /// <summary>
        /// Adds new subscription
        /// </summary>
        public async Task<Subscription> AddSubscription(PaymentModel payment)
        {
            return await Subscribe(payment);
        }

        /// <summary>
        /// Updates or downgrades current subscription
        /// </summary>
        /// <returns></returns>
        public async Task<Subscription> UpdateSubscription(PaymentModel payment)
        {
            var customerSubscription = await GetCustomerSubscription(payment.CustomerId); // get current
            var subscriptionService = new SubscriptionService();

            var subscriptions = new List<SubscriptionItemOptions>()
            {
                new SubscriptionItemOptions ()
                {
                    Id = customerSubscription.Id,
                    Plan = payment.PlanId,
                }
            };

            var options = new SubscriptionUpdateOptions
            {
                CancelAtPeriodEnd = false,
                Items = subscriptions,
            };

            var subscription = await subscriptionService.UpdateAsync(customerSubscription.Id, options);

            return subscription;
        }

        /// <summary>
        /// Subscribes - new subscription
        /// </summary>
        /// <returns></returns>
        private async Task<Subscription> Subscribe(PaymentModel payment)
        {
            var subscriptions = new List<SubscriptionItemOptions>()
            {
                new SubscriptionItemOptions()
                {
                    Plan = payment.PlanId,
                    Quantity = 1,
                }
            };

            var subscriptionService = new SubscriptionService();
            var subscriptionOptions = new SubscriptionCreateOptions()
            {
                Customer = payment.CustomerId,
                CancelAtPeriodEnd = false,
                Items = subscriptions,
            };

            return await subscriptionService.CreateAsync(subscriptionOptions);
        }

        public async Task<Subscription> GetCustomerSubscription(string customerId)
        {
            var subscriptionService = new SubscriptionService();
            var subscriptions = await subscriptionService.ListAsync(new SubscriptionListOptions()
            {
                Customer = customerId,
            });

            return subscriptions.Data.FirstOrDefault();
        }

        public async Task CancelSubscription(string subscriptionId)
        {
            var subscriptionService = new SubscriptionService();
            await subscriptionService.CancelAsync(subscriptionId,
                new SubscriptionCancelOptions()
                {
                    InvoiceNow = true
                });
        }

        public async Task<IEnumerable<Plan>> GetAvailablePlans(bool basic = true)
        {
            var planService = new PlanService();

            var plans = await planService.ListAsync(new PlanListOptions()
            {
                Active = true,
            });

            // only get those specified in products.json
            if (basic && plans.Any())
            {
                var productNames = StripeConfiguration.GetProducts().Products.First().Plans.Select(x => x.Name); // only one product.. 3 subscriptions

                plans.Data = plans.Data.Where(x => productNames.Contains(x.Nickname)).ToList();
            }

            return plans;
        }

        public async Task<SubscriptionStatus> GetCustomerSubscriptionStatus(string customerId)
        {
            var service = new SubscriptionService();
            var options = new SubscriptionListOptions()
            {
                Customer = customerId,
            };

            var subscriptions = await service.ListAsync(options);

            if (subscriptions.Any())
                return (SubscriptionStatus)Enum.Parse(typeof(SubscriptionStatus), subscriptions.First().Status, true);

            return SubscriptionStatus.Unpaid;
        }
    }
}