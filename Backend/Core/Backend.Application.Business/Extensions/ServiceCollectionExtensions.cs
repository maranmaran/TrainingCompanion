using AutoMapper;
using Backend.Domain.Extensions;
using Backend.Service.AmazonS3.Extensions;
using Backend.Service.Authorization.Extensions;
using Backend.Service.Email.Extensions;
using Backend.Service.Payment.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Backend.Application.Business.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures all core services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.ConfigureAuthorizationServices();
            services.ConfigureEmailServices();
            services.ConfigurePaymentServices();
            services.ConfigureS3Services();
        }

        public static void ConfigureCoreSettings(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureJwtSettings(config);
            services.ConfigureEmailSettings(config);
            services.ConfigurePaymentSettings(config);
            services.ConfigureAppSettings(config);
            services.ConfigureS3Settings(config);
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
            services.AddAutoMapper(typeof(CoreMappingsProfile));
        }

    }
}
