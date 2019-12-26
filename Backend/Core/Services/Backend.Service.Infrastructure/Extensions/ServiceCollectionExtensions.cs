using Backend.Service.Infrastructure.Providers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Backend.Service.Infrastructure.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
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