using Backend.Service.Infrastructure.Providers;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Backend.Service.Infrastructure.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures all core services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            //services.ConfigureAuthorizationServices();
            //services.ConfigureEmailServices();
            //services.ConfigurePaymentServices();
            //services.ConfigureS3Services();
            //services.ConfigureNotificationServices();
            //services.ConfigureExcelService();
            //services.ConfigureLoggingService();
        }

        public static void ConfigureCoreSettings(this IServiceCollection services, IConfiguration config)
        {
            //services.ConfigureJwtSettings(config);
            //services.ConfigureEmailSettings(config);
            //services.ConfigurePaymentSettings(config);
            //services.ConfigureAppSettings(config);
            //services.ConfigureS3Settings(config);
        }

        /// <summary>
        /// Configures MediatR for request pipeline and adds some middleware
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }

        /// <summary>
        /// Configures automapper using automapper extension for dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(CoreMappingsProfile));
        }

        /// <summary>
        /// Configures Core mailing services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureNotificationServices(this IServiceCollection services)
        {
            //services.AddTransient<INotificationService, NotificationService>();
        }

        public static void ConfigureSignalR(this IServiceCollection services)
        {
            services
                .AddSignalR(options =>
                {
                    options.EnableDetailedErrors = true;
                })
                .AddNewtonsoftJsonProtocol(options =>
                {
                    options.PayloadSerializerSettings = new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented,
                        Converters = new List<JsonConverter>()
                        {
                            new StringEnumConverter()
                        },
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    };
                });

            // Change to use Name as the user identifier for SignalR
            // WARNING: This requires that the source of your JWT token
            // ensures that the Name claim is unique!
            // If the Name claim isn't unique, users could receive messages
            // intended for a different user!

            // For this application implementation claim type NAME of JWT is USERID so it is Unique
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
        }
    }
}