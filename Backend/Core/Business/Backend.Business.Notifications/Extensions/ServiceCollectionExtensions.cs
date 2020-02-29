using Backend.Business.Notifications;
using Backend.Business.Notifications.PushNotification;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Infrastructure.Extensions
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