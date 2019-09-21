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

                // SEED OTHER DATA
                admin = ExercisePropertiesFactory.ApplyProperties<Admin>(admin);
                admin = ExerciseTypesFactory.ApplyExercises<Admin>(admin);

                coach = ExercisePropertiesFactory.ApplyProperties<Coach>(coach);
                coach = ExerciseTypesFactory.ApplyExercises<Coach>(coach);

                soloAthlete = ExercisePropertiesFactory.ApplyProperties<SoloAthlete>(soloAthlete);
                soloAthlete = ExerciseTypesFactory.ApplyExercises<SoloAthlete>(soloAthlete);

                athlete = ExercisePropertiesFactory.ApplyProperties<Athlete>(athlete);
                athlete = ExerciseTypesFactory.ApplyExercises<Athlete>(athlete);


                context.Users.Add(admin);
                context.Users.Add(coach);
                context.Users.Add(soloAthlete);
                context.SaveChangesAsync(CancellationToken.None).Wait();

                // JOIN SEEDED DATA - MANY TO MANY
                context.ExerciseTypeExerciseProperties.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(admin));
                context.ExerciseTypeExerciseProperties.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(coach));
                context.ExerciseTypeExerciseProperties.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(athlete));
                context.ExerciseTypeExerciseProperties.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(soloAthlete));

                context.SaveChangesAsync(CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
