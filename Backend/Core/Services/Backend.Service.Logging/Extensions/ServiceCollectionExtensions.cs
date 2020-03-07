using Backend.Library.Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Library.Logging.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureLoggingService(this IServiceCollection services)
        {
            services.AddTransient<ILoggingService, LoggingService>();
        }
    }
}