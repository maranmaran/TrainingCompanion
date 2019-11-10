using Backend.Domain;
using Backend.Persistance;
using Backend.Service.Payment.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Backend.Service.Payment.Configuration;
using Microsoft.Extensions.Hosting;

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var contextInterface = services.GetService<IApplicationDbContext>();
                    //var stripeConfiguration = services.GetService<IStripeConfiguration>();
                    //var passwordHasher = services.GetService<IPasswordHasher>();

                    StripeConfiguration.ConfigureProducts().Wait();

                    var context = (ApplicationDbContext)contextInterface;
                    context.Database.Migrate();
                    //DatabaseInitializer.Initialize(context, stripeConfiguration, passwordHasher);//<---Do your seeding here
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
