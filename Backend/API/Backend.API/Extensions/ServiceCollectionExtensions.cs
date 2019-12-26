using Backend.API.LibraryConfigurations.Sieve;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Domain;
using Backend.Persistance;
using Backend.Service.Authorization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Sieve.Models;
using Sieve.Services;
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
        /// Configures Biarity/Sieve library for out of the box sorting, filtering and paginating functionality
        /// CreateUseres sieve options from application setting
        /// CreateUsers dependency injection for sieve processor and any custom filtering and sorting
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSieve(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
            services.Configure<SieveOptions>(configuration.GetSection("SieveOptions"));
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
    }
}