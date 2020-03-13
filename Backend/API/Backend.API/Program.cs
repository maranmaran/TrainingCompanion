using Backend.Domain;
using Backend.Library.Payment.Configuration;
using Backend.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    logger.Error("Application started");
                    var contextInterface = services.GetService<IApplicationDbContext>();
                    var stripeSettings = services.GetService<StripeSettings>();
                    //var passwordHasher = services.GetService<IPasswordHasher>();

                    StripeConfiguration.ConfigureProducts(stripeSettings).Wait();

                    var context = (ApplicationDbContext)contextInterface;
                    context.Database.Migrate();
                    //DatabaseInitializer.Initialize(context, stripeConfiguration, passwordHasher);//<---Do your seeding here
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Internal server error in Main. Perhaps DB failed to migrate or seed.");
                }
                finally
                {
                    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                    NLog.LogManager.Shutdown();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace); // App settings override this
                })
                .UseNLog();
    }
}