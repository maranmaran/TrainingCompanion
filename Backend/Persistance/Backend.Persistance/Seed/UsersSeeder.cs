using Backend.Business.Authorization.Utils;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using System;

namespace Backend.Persistance.Seed
{
    public static class UsersSeeder
    {
        public static (Admin, Athlete, Coach, SoloAthlete) GetUsers()
        {
            var admin = new Admin()
            {
                Id = Guid.Parse("0faee6ac-1772-4bbe-9990-a7d9a22dd529"),
                FirstName = "Admin",
                LastName = "",
                Username = "admin",
                Email = "admin@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("admin"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FLi7gZv8w0j0GB",
                UserSettingId = Guid.Parse("0d528a91-fbbe-4a02-924a-792344bbbd65")
            };
            var athlete = new Athlete()
            {
                Id = Guid.Parse("8d399c00-5654-4a54-9c2c-b44a485c3583"),
                FirstName = "Athlete",
                LastName = "",
                Username = "athlete",
                Email = "athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("athlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserSettingId = Guid.Parse("8d399c00-5684-4a54-9c2c-b44a485c3583")
            };
            var soloAthlete = new SoloAthlete()
            {
                Id = Guid.Parse("939085da-e515-4422-80eb-7847e7f4eadb"),
                FirstName = "Solo",
                LastName = "Athlete",
                Username = "soloathlete",
                Email = "solo.athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("soloathlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserSettingId = Guid.Parse("46bd253c-a630-4759-a2a5-a4ec7497c88a")
            };
            var coach = new Coach()
            {
                Id = Guid.Parse("fa67c815-486e-4e9d-89dd-3156376ac9b4"),
                FirstName = "Coach",
                LastName = "",
                Username = "coach",
                Email = "coach@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("coach"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FHk5RepADdfm5H",
                UserSettingId = Guid.Parse("051fde35-1f15-4ffe-81d0-e67e2459a6c5")
            };

            athlete.CoachId = coach.Id;
            return (admin, athlete, coach, soloAthlete);
        }
    }
}