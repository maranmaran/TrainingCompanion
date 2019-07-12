using Backend.Service.Infrastructure.Providers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Infrastructure.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureSignalR(this IServiceCollection services)
        {
            services.AddSignalR(o => { o.EnableDetailedErrors = true; });

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