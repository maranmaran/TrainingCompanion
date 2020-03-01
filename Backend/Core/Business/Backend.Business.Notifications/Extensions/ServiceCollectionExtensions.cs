using Backend.Business.Notifications.Interfaces;
using Backend.Business.Notifications.PushNotificationRequests;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Business.Notifications.Extensions
{
    public static partial class ServiceCollectionExtensions
    {

        /// <summary>
        /// Configures Core mailing services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureNotificationServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
        }

    }
}