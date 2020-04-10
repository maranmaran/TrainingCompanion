using Backend.Business.Dashboard.Interfaces;
using Backend.Business.Dashboard.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Business.Dashboard.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures Core dashboard services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDashboardServices(this IServiceCollection services)
        {
            services.AddTransient<IActivityService, ActivityService>();
        }
    }
}
