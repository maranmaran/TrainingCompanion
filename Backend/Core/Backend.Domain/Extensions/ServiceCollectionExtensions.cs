using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Domain.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Gets relevant app setting from appSettings.json and maps to POCO classes and configures singleton for DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind("AppSettings", appSettings);
            services.AddSingleton<AppSettings>(appSettings); // add singleton for DI
        }
    }
}