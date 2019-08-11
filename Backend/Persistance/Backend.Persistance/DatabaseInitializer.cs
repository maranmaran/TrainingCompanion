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
                    Email = "admin@trainingcompanion.com",
                    Active = true,
                    AccountType = AccountType.Admin,
                    Gender = Gender.Male,
                    PasswordHash = _passwordHasher.GetPasswordHash("admin"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FLi7gZv8w0j0GB",
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("Admin").Round().Background().Foreground().Value(),
                };

                var athlete = new Athlete()
                {
                    FirstName = "Athlete",
                    LastName = "",
                    Username = "athlete",
                    Email = "athlete@trainingcompanion.com",
                    Gender = Gender.Male,
                    Active = true,
                    AccountType = AccountType.Athlete,
                    PasswordHash = _passwordHasher.GetPasswordHash("athlete"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("Athlete").Round().Background().Foreground().Value(),
                };

                var coach = new Coach()
                {
                    FirstName = "Coach",
                    LastName = "",
                    Username = "coach",
                    Email = "coach@trainingcompanion.com",
                    AccountType = AccountType.Coach,
                    Gender = Gender.Male,
                    Active = true,
                    PasswordHash = _passwordHasher.GetPasswordHash("coach"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FHk5RepADdfm5H",
                    UserSettings = new UserSettings(),
                    Avatar = new GenericAvatarConstructor().AddName("Coach").Round().Background().Foreground().Value(),
                    Athletes = new List<Athlete>() { athlete }
                };

                _context.Users.Add(admin);
                _context.Users.Add(coach);
                _context.SaveChangesAsync(CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
