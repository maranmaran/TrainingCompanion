using Backend.Service.Authorization.Interfaces;
using Backend.Service.Authorization.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Authorization.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Gets relevant app setting from appSettings.json and maps to POCO classes and configures singleton for DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureJwtSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);
            services.AddSingleton<JwtSettings>(jwtSettings); // add singleton for DI
        }

        /// <summary>
        /// Configures Core authorization services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAuthorizationServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        }
    }
}