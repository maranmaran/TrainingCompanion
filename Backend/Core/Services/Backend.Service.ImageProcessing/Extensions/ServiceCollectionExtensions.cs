using Backend.Service.ImageProcessing.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.ImageProcessing.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Gets relevant app setting from appSettings.json and maps to POCO classes and configures singleton for DI
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureS3Settings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ImageProcessingSettings();
            configuration.Bind("ImageProcessingSettings", settings);
            services.AddSingleton<ImageProcessingSettings>(settings); // add singleton for DI
        }

        /// <summary>
        /// Configures Core authorization services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureImageProcessingServices(this IServiceCollection services)
        {
            services.AddTransient<IImageProcessingService, ImageProcessingService>();
        }
    }
}
