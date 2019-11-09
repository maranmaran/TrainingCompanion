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
using Backend.Service.Authorization.Utils;
using Backend.Service.Payment.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistance
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder b)
        {
            var userIds = SeedUsers(b);
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

                    tagGroup.Tags = null; // to avoid "Navigation property is set" error because you have to ONLY connect entities through pre-set IDs
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
        private static IEnumerable<Guid> SeedUsers(ModelBuilder b)
        {
            var users = UsersFactory.GetUsers();

            b.Entity<Admin>().HasData(users.Item1);
            b.Entity<Athlete>().HasData(users.Item2);
            b.Entity<Coach>().HasData(users.Item3);
            b.Entity<SoloAthlete>().HasData(users.Item4);

            return new List<Guid>()
            {
                users.Item1.Id,
                users.Item2.Id,
                users.Item3.Id,
                users.Item4.Id
            };
        }
    }
}
