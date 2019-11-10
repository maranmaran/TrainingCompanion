using Backend.Application.Business.Factories;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Authorization.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Backend.Service.Authorization.Utils;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistance.Seed
{
    public static class UsersFactory
    {
        public static (Admin, Athlete, Coach, SoloAthlete) GetUsers()
        {
            var admin = new Admin()
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "",
                Username = "admin",
                Email = "admin@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("admin"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FLi7gZv8w0j0GB",
                UserSettingId = Guid.NewGuid()
            };


            var athlete = new Athlete()
            {
                Id = Guid.NewGuid(),
                FirstName = "Athlete",
                LastName = "",
                Username = "athlete",
                Email = "athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("athlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserSettingId = Guid.NewGuid()
            };


            var soloAthlete = new SoloAthlete()
            {
                Id = Guid.NewGuid(),
                FirstName = "Solo",
                LastName = "Athlete",
                Username = "soloathlete",
                Email = "solo.athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("soloathlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserSettingId = Guid.NewGuid()
            };

            var coach = new Coach()
            {
                Id = Guid.NewGuid(),
                FirstName = "Coach",
                LastName = "",
                Username = "coach",
                Email = "coach@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = PasswordHasher.GetPasswordHash("coach"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FHk5RepADdfm5H",
                UserSettingId = Guid.NewGuid()
            };

            athlete.CoachId = coach.Id;

            return (admin, athlete, coach, soloAthlete);
        }
    }
}
