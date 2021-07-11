using Backend.Library.MediaCompression.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Library.MediaCompression.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Gets relevant app setting from appSettings.json and maps to POCO classes and configures singleton for DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureMediaCompressionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new MediaCompressionSettings();
            configuration.Bind("MediaCompressionSettings", settings);
            services.AddSingleton(settings); // add singleton for DI
        }

        /// <summary>
        /// Configures Core authorization services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMediaCompressionService(this IServiceCollection services)
        {
            services.AddTransient<IMediaCompressionService, MediaCompressionService>();
        }
    }
}