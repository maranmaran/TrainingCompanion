using Backend.Library.Email.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Library.Email.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureEmailSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var emailSettings = new EmailSettings();
            configuration.Bind("EmailSettings", emailSettings);
            services.AddSingleton<EmailSettings>(emailSettings);
        }

        /// <summary>
        /// Configures Core mailing services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureEmailServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}