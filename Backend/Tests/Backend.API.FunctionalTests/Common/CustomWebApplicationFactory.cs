using Backend.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Backend.Domain;
using Backend.Service.Authorization;
using Backend.Service.Authorization.Interfaces;

namespace Backend.API.FunctionalTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ServiceProvider ServiceProvider { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context using an in-memory 
                // database for testing.
                services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddSingleton<AppSettings>();


                // Build the service provider.
                ServiceProvider = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context
                using (var scope = ServiceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<IApplicationDbContext>();

                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var concreteContext = (ApplicationDbContext)context;

                    // Ensure the database is created.
                    concreteContext.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        Utilities.InitializeDbForTests(concreteContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                                            "database with test messages. Error: {ex.ChatMessage}");
                    }
                }
            });
        }
    }
}
