using Backend.Library.Logging.Interfaces;
using Backend.Library.Logging.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;

namespace Backend.Library.Logging.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureLogLevelSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new LogLevelSettings();
            configuration.Bind("Logging:LogLevel", settings);
            services.AddSingleton<LogLevelSettings>(settings); // add singleton for DI
        }

        public static void ConfigureNLog(this IServiceCollection services)
        {
            // logging configuration
            NLogBuilder.ConfigureNLog("nlog.config");
        }

        public static void ConfigureLoggingService(this IServiceCollection services)
        {
            // scoped as application db context.. one per request
            services.AddScoped<ILoggingService, LoggingService>();
        }
    }
}