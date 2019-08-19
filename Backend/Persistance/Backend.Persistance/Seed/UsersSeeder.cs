using Backend.Application.Business.Factories;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Backend.Persistance.Seed
{
    public static class UsersSeeder
    {
        public static void SeedUsers(IApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            try
            {
                var admin = new Admin()
                {
                    FirstName = "Admin",
                    LastName = "",
                    Username = "admin",
                    Email = "admin@trainingcompanion.com",
                    Gender = Gender.Male,
                    PasswordHash = passwordHasher.GetPasswordHash("admin"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FLi7gZv8w0j0GB",
                    UserSettings = new UserSettings(),
                };
                admin = ExerciseTypePropertiesFactory.ApplyProperties<Admin>(admin);

                var athlete = new Athlete()
                {
                    FirstName = "Athlete",
                    LastName = "",
                    Username = "athlete",
                    Email = "athlete@trainingcompanion.com",
                    Gender = Gender.Male,
                    PasswordHash = passwordHasher.GetPasswordHash("athlete"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    UserSettings = new UserSettings(),
                };
                athlete = ExerciseTypePropertiesFactory.ApplyProperties<Athlete>(athlete);


                var soloAthlete = new SoloAthlete()
                {
                    FirstName = "Solo",
                    LastName = "Athlete",
                    Username = "soloathlete",
                    Email = "solo.athlete@trainingcompanion.com",
                    Gender = Gender.Male,
                    PasswordHash = passwordHasher.GetPasswordHash("soloathlete"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    UserSettings = new UserSettings(),
                };
                soloAthlete = ExerciseTypePropertiesFactory.ApplyProperties<SoloAthlete>(soloAthlete);

                var coach = new Coach()
                {
                    FirstName = "Coach",
                    LastName = "",
                    Username = "coach",
                    Email = "coach@trainingcompanion.com",
                    Gender = Gender.Male,
                    PasswordHash = passwordHasher.GetPasswordHash("coach"),
                    CreatedOn = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    CustomerId = "cus_FHk5RepADdfm5H",
                    UserSettings = new UserSettings(),
                    Athletes = new List<Athlete>() { athlete }
                };
                coach = ExerciseTypePropertiesFactory.ApplyProperties<Coach>(coach);

                context.Users.Add(admin);
                context.Users.Add(coach);
                context.Users.Add(soloAthlete);
                context.SaveChangesAsync(CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
