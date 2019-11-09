using Backend.Application.Business.Factories;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;

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
                    UserSetting = new UserSetting(),
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
                    UserSetting = new UserSetting(),
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
                    UserSetting = new UserSetting(),
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
                    UserSetting = new UserSetting(),
                    Athletes = new List<Athlete>() { athlete }
                };

                // SEED OTHER DATA
                admin = ExerciseTagGroupsFactory.ApplyProperties<Admin>(admin);
                admin = ExerciseTypesFactory.ApplyExercises<Admin>(admin);

                coach = ExerciseTagGroupsFactory.ApplyProperties<Coach>(coach);
                coach = ExerciseTypesFactory.ApplyExercises<Coach>(coach);

                soloAthlete = ExerciseTagGroupsFactory.ApplyProperties<SoloAthlete>(soloAthlete);
                soloAthlete = ExerciseTypesFactory.ApplyExercises<SoloAthlete>(soloAthlete);

                athlete = ExerciseTagGroupsFactory.ApplyProperties<Athlete>(athlete);
                athlete = ExerciseTypesFactory.ApplyExercises<Athlete>(athlete);

                context.Users.Add(admin);
                context.Users.Add(coach);
                context.Users.Add(soloAthlete);
                context.SaveChangesAsync(CancellationToken.None).Wait();

                // JOIN SEEDED DATA - MANY TO MANY
                context.ExerciseTypeTags.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(admin));
                context.ExerciseTypeTags.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(coach));
                context.ExerciseTypeTags.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(athlete));
                context.ExerciseTypeTags.AddRange(ExerciseTypeTagFactory.JoinExerciseTypesAndProperties(soloAthlete));

                context.SaveChangesAsync(CancellationToken.None).Wait();
            }
            catch (Exception e)
            {
                throw new Exception("Setting admin user went wrong", e);
            }
        }
    }
}
