using AutoMapper;
using Backend.Business.Authorization;
using Backend.Business.Authorization.Extensions;
using Backend.Business.Users.UsersRequests.CreateUser;
using Backend.Domain;
using Backend.Domain.Extensions;
using Backend.Library.AmazonS3.Extensions;
using Backend.Library.Email.Extensions;
using Backend.Library.ImageProcessing.Extensions;
using Backend.Library.Logging.Extensions;
using Backend.Library.Payment.Extensions;
using Backend.Persistance;
using Backend.Service.Infrastructure.Providers;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.API.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// CORS policies
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAllCorsPolicy",
                    builder => builder
                        .WithOrigins("https://localhost:4200", "http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });
        }

        /// <summary>
        /// Configures MVC filters, json options and createUsers validators
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>())
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.AllowInputFormatterExceptionMessages = true;
                });
        }

        /// <summary>
        /// Adds database context and initializes database using connection string provided
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseLazyLoadingProxies();
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //TODO: Revisit this setting
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        }

        /// <summary>
        /// Adds and configures JWT Token based authorization
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettingsSection = configuration.GetSection("JwtSettings"); // get app setting section
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>(); // get instance of forementioned POCO CLASS
            var jwtSecretKey = Encoding.ASCII.GetBytes(jwtSettings.JwtSecret); // extract secret

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtSecretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    // We have to hook the OnMessageReceived event in order to
                    // allow the JWT authentication handler to read the access
                    // token from the query string when a WebSocket or
                    // Server-Sent Events request comes in.
                    //https://docs.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-2.2
                    x.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Cookies["jwt"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && (path.Equals("/api/chat-hub") ||
                                                                       path.Equals("/api/notifications-hub")
                                ))
                            {
                                // Read the token out of the query string
                                context.Token = $"{accessToken}";
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        /// <summary>
        /// Configures swagger ( Swashbuckle Core )
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(action =>
            {
                action.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Backend API", Version = "1.0" });

                action.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        /// <summary>
        /// Configures MediatR for request pipeline and adds some middleware
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var assemblies = new List<Assembly>()
            {
                Assembly.GetAssembly(typeof(Business.Billing.Mappings)),
                Assembly.GetAssembly(typeof(Business.Authorization.Mappings)),
                Assembly.GetAssembly(typeof(Business.Media.Mappings)),
                Assembly.GetAssembly(typeof(Business.Chat.Mappings)),
                Assembly.GetAssembly(typeof(Business.Export.Mappings)),
                Assembly.GetAssembly(typeof(Business.Import.Mappings)),
                Assembly.GetAssembly(typeof(Business.Metrics.Mappings)),
                Assembly.GetAssembly(typeof(Business.Notifications.Mappings)),
                Assembly.GetAssembly(typeof(Business.ProgressTracking.Mappings)),
                Assembly.GetAssembly(typeof(Business.TrainingLog.Mappings)),
                Assembly.GetAssembly(typeof(Business.Users.Mappings)),
                Assembly.GetAssembly(typeof(Business.ExerciseType.Mappings)),
            };

            services.AddMediatR(assemblies.ToArray());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
        }

        /// <summary>
        /// Configures automapper using automapper extension for dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            var mappings = new List<Type>()
            {
                typeof(Business.Billing.Mappings),
                typeof(Business.Authorization.Mappings),
                typeof(Business.Media.Mappings),
                typeof(Business.Chat.Mappings),
                typeof(Business.Export.Mappings),
                typeof(Business.Import.Mappings),
                typeof(Business.Metrics.Mappings),
                typeof(Business.Notifications.Mappings),
                typeof(Business.ProgressTracking.Mappings),
                typeof(Business.TrainingLog.Mappings),
                typeof(Business.Users.Mappings),
                typeof(Business.ExerciseType.Mappings),
            };

            services.AddAutoMapper(mappings.ToArray());
        }

        /// <summary>
        /// Configures signalR
        /// </summary>
        /// <param name="services"></param>
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

        /// <summary>
        /// Configures all core services (business and shared)
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.ConfigureAuthorizationServices();
            services.ConfigureEmailServices();
            services.ConfigurePaymentServices();
            services.ConfigureS3Services();
            services.ConfigureLoggingService();
            services.ConfigureImageProcessingServices();
        }

        /// <summary>
        /// Configures core settings
        /// </summary>
        public static void ConfigureCoreSettings(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureJwtSettings(config);
            services.ConfigureEmailSettings(config);
            services.ConfigurePaymentSettings(config);
            services.ConfigureAppSettings(config);
            services.ConfigureS3Settings(config);
        }
    }
}