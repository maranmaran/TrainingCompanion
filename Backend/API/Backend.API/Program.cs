using Backend.Domain;
using Backend.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Backend.Library.Payment.Configuration;

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
                    var stripeSettings = services.GetService<StripeSettings>();
                    //var passwordHasher = services.GetService<IPasswordHasher>();

                    StripeConfiguration.ConfigureProducts(stripeSettings).Wait();

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