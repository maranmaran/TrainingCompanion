using Backend.Domain;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Backend.Application.Business.Factories;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Persistance.Seed;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistance
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder b, IStripeConfiguration stripeConfig, IPasswordHasher pwHasher)
        {
            stripeConfig.ConfigureProducts();

            var userIds = SeedUsers(b, pwHasher);
            var userSettingIds = SeedUserSettings(b, userIds);
            SeedNotificationSettings(b, userSettingIds);
            
            SeedTags(b, userIds);
            SeedExerciseTypes(b, userIds);
            SeedExerciseTypeTags(b);
        }

        private static void SeedExerciseTypeTags(ModelBuilder b)
        {
            var types = ExerciseTypesFactory.GetExerciseTypes().ToList();
            var tags = ExerciseTagGroupsFactory.GetTagGroups().ToList();

            var joinValues = ExerciseTypeTagFactory.GetJoinValues(tags, types);
            foreach (var joinValue in joinValues)
            {
                joinValue.Id = Guid.NewGuid();
                b.Entity<ExerciseTypeTag>().HasData(joinValue);
            }
        }
        private static void SeedExerciseTypes(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            foreach (var userId in userIds)
            { 
                ExerciseTypesFactory.GetExerciseTypes().ToList()
                    .ForEach(type =>
                    {
                        type.Id = Guid.NewGuid();
                        type.ApplicationUserId = userId;

                        b.Entity<ExerciseType>().HasData(type);
                    });
            }
        }
        private static void SeedTags(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            foreach (var userId in userIds)
            {
                var tagGroups = ExerciseTagGroupsFactory.GetTagGroups();
                foreach (var tagGroup in tagGroups)
                {
                    tagGroup.Id = Guid.NewGuid();
                    tagGroup.ApplicationUserId = userId;

                    foreach (var tag in tagGroup.Tags)
                    {
                        tag.TagGroupId = tagGroup.Id;
                        tag.Id = Guid.NewGuid();

                        b.Entity<Tag>().HasData(tag);
                    }

                    b.Entity<TagGroup>().HasData(tagGroup);
                }
            }
        }
        private static void SeedNotificationSettings(ModelBuilder b, IEnumerable<Guid> userSettingIds)
        {
            foreach (var userSettingId in userSettingIds)
            {

                var values = EnumSeeder.SeedEnum<NotificationType, NotificationSetting>((value) => new NotificationSetting() 
                {
                    Id = Guid.NewGuid(),
                    NotificationType = value,
                    UserSettingId = userSettingId
                }).ToList();
                
                b.Entity<NotificationSetting>().HasData(values);
            }
        }
        private static IEnumerable<Guid> SeedUserSettings(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            var userSettingIds = new List<Guid>();

            foreach (var userId in userIds)
            {
                var userSetting = new UserSetting()
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = userId
                };

                userSettingIds.Add(userSetting.Id);
                b.Entity<UserSetting>().HasData(userSetting);
            }

            return userSettingIds;
        }
        private static IEnumerable<Guid> SeedUsers(ModelBuilder b, IPasswordHasher hasher)
        {
            var userIds = new Guid[4];
            Array.Fill(userIds, Guid.NewGuid());

            var admin = new Admin()
            {
                Id = userIds[0],
                FirstName = "Admin",
                LastName = "",
                Username = "admin",
                Email = "admin@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = hasher.GetPasswordHash("admin"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FLi7gZv8w0j0GB",
            };
            var athlete = new Athlete()
            {
                Id = userIds[1],
                FirstName = "Athlete",
                LastName = "",
                Username = "athlete",
                Email = "athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = hasher.GetPasswordHash("athlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
            var soloAthlete = new SoloAthlete()
            {
                Id = userIds[2],
                FirstName = "Solo",
                LastName = "Athlete",
                Username = "soloathlete",
                Email = "solo.athlete@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = hasher.GetPasswordHash("soloathlete"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
            var coach = new Coach()
            {
                Id = userIds[3],
                FirstName = "Coach",
                LastName = "",
                Username = "coach",
                Email = "coach@trainingcompanion.com",
                Gender = Gender.Male,
                PasswordHash = hasher.GetPasswordHash("coach"),
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                CustomerId = "cus_FHk5RepADdfm5H",
                UserSetting = new UserSetting(),
            };

            b.Entity<Admin>().HasData(admin);
            b.Entity<Athlete>().HasData(athlete);
            b.Entity<SoloAthlete>().HasData(soloAthlete);
            b.Entity<Coach>().HasData(coach);

            return userIds;
        }
    }

    //public class DatabaseInitializer
    //{
    //    private readonly IApplicationDbContext _context;
    //    private readonly IStripeConfiguration _stripeConfiguration;
    //    private readonly IPasswordHasher _passwordHasher;

    //    public DatabaseInitializer(
    //        IApplicationDbContext context,
    //        IStripeConfiguration stripeConfiguration,
    //        IPasswordHasher passwordHasher)
    //    {
    //        _context = context;
    //        _stripeConfiguration = stripeConfiguration;
    //        _passwordHasher = passwordHasher;
    //    }


    //    public static void Initialize(
    //        IApplicationDbContext context,
    //        IStripeConfiguration stripeConfiguration,
    //        IPasswordHasher passwordHasher)
    //    {
    //        var initializer = new DatabaseInitializer(context, stripeConfiguration, passwordHasher);
    //        initializer.SeedDatabase(context);
    //    }

    //    public void SeedDatabase(IApplicationDbContext context)
    //    {
    //        if (context.Users != null && context.Users.Any())
    //        {
    //            return; //Db seeded
    //        }

    //        SeedUsers(context);
    //        SeedNotificationSettings(context);
    //        _stripeConfiguration.ConfigureProducts();
    //    }

    //    public void SeedUsers(IApplicationDbContext context)
    //    {
    //        try
    //        {
    //            UsersSeeder.SeedUsers(_context, _passwordHasher);
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception("Seeding users went wrong", e);
    //        }
    //    }

    //    public void SeedNotificationSettings(IApplicationDbContext context)
    //    {
    //        try
    //        {
    //            var values = EnumSeeder.SeedEnum<NotificationType, NotificationSetting>((value) => new NotificationSetting()
    //            {
    //                NotificationType = value
    //            });

    //            context.NotificationSetting.AddRange(values);
    //            context.SaveChangesAsync(CancellationToken.None).Wait();
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception("Seeding notification settings went wrong");
    //        }
    //    }

    //}
}
