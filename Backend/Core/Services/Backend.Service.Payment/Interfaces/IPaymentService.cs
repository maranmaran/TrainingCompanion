using Backend.Service.Payment.Enums;
using Backend.Service.Payment.Models;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plan = Stripe.Plan;

namespace Backend.Service.Payment.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Subscribes customer to specific plan
        /// </summary>
        /// <returns></returns>
        Task<Subscription> AddSubscription(PaymentModel payment);

        /// <summary>
        /// Updates or downgrades current subscription
        /// </summary>
        Task<Subscription> UpdateSubscription(PaymentModel payment);

        /// <summary>
        /// Adds payment option for customer via token
        /// </summary>
        /// <param name="paymentOption"></param>
        /// <returns></returns>
        Task AddPaymentOption(PaymentOption paymentOption);

        /// <summary>
        /// Gets all customer subscription
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Subscription> GetCustomerSubscription(string customerId);

        /// <summary>
        /// Cancels specific subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        Task CancelSubscription(string subscriptionId);

        /// <summary>
        /// Gets all available plans
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Plan>> GetAvailablePlans();

        /// <summary>
        /// Gets customers subscription status
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<SubscriptionStatus> GetCustomerSubscriptionStatus(string customerId);
    }
}
