using Backend.Service.AmazonS3.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.AmazonS3.Extensions
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
            var s3Settings = new S3Settings();
            configuration.Bind("S3Settings", s3Settings);
            services.AddSingleton<S3Settings>(s3Settings); // add singleton for DI
        }

        /// <summary>
        /// Configures Core authorization services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureS3Services(this IServiceCollection services)
        {
            services.AddTransient<IS3Service, S3Service>();
        }
    }
}