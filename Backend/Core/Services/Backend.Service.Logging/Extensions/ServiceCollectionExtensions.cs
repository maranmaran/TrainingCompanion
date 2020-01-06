using Backend.Service.Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Logging.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureLoggingService(this IServiceCollection services)
        {
            services.AddTransient<ILoggingService, LoggingService>();
        }
    }
}