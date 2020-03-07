using Backend.Library.Payment.Configuration;
using Backend.Library.Payment.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Library.Payment.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigurePaymentSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var stripeSettings = new StripeSettings();
            configuration.Bind("StripeSettings", stripeSettings);
            services.AddSingleton<StripeSettings>(stripeSettings);
        }

        /// <summary>
        /// Configures Core payment services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigurePaymentServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentService, PaymentService>();
        }
    }
}