using Backend.Domain;
using Backend.Persistance.Seed;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Payment.Interfaces;
using System;
using System.Linq;

namespace Backend.Persistance
{
    public class DatabaseInitializer
    {
        private readonly IApplicationDbContext _context;
        private readonly IStripeConfiguration _stripeConfiguration;
        private readonly IPasswordHasher _passwordHasher;

        public DatabaseInitializer(
            IApplicationDbContext context,
            IStripeConfiguration stripeConfiguration,
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _stripeConfiguration = stripeConfiguration;
            _passwordHasher = passwordHasher;
        }


        public static void Initialize(
            IApplicationDbContext context,
            IStripeConfiguration stripeConfiguration,
            IPasswordHasher passwordHasher)
        {
            var initializer = new DatabaseInitializer(context, stripeConfiguration, passwordHasher);
            initializer.SeedDatabase(context);
        }

        public void SeedDatabase(IApplicationDbContext context)
        {
            if (context.Users != null && context.Users.Any())
            {
                return; //Db seeded
            }

            SeedUsers(context);
            _stripeConfiguration.ConfigureProducts();
        }

        public void SeedUsers(IApplicationDbContext context)
        {
            try
            {
                UsersSeeder.SeedUsers(_context, _passwordHasher);
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
