using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                var admin = new ApplicationUser()
                {
                    FirstName = "Admin",
                    LastName = "",
                    Username = "admin",
                    Email = "urh.marko@gmail.com",
                    AccountStatus = AccountStatus.Active,
                    AccountType = AccountType.Admin,
                    PasswordHash = _passwordHasher.GetPasswordHash("admin"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FLi7gZv8w0j0GB",
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("Admin").Round().Background().Foreground().Value(),
                };

                var subuser = new ApplicationUser()
                {
                    FirstName = "Subuser",
                    LastName = "",
                    Username = "subuser",
                    Email = "urh.marko@gmail.com",
                    AccountStatus = AccountStatus.Active,
                    AccountType = AccountType.Subuser,
                    PasswordHash = _passwordHasher.GetPasswordHash("subuser"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("Subuser").Round().Background().Foreground().Value(),
                };

                var user = new ApplicationUser()
                {
                    FirstName = "User",
                    LastName = "",
                    Username = "user",
                    Email = "urh.marko@gmail.com",
                    AccountStatus = AccountStatus.Active,
                    AccountType = AccountType.User,
                    PasswordHash = _passwordHasher.GetPasswordHash("user"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FHk5RepADdfm5H",
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("User").Round().Background().Foreground().Value(),
                    Subusers = new List<ApplicationUser>() { subuser }
                };

                _context.Users.Add(admin);
                _context.Users.Add(user);
                _context.SaveChangesAsync(CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
