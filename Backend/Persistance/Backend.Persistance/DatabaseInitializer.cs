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
using Microsoft.EntityFrameworkCore.Internal;

namespace Backend.Persistance
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder b)
        {
            var users = SeedUsers(b);
            var userSettingIds = SeedUserSettings(b, users.Select(x => x.Id).ToArray(), users.Select(x=>x.UserSettingId).ToArray());
            SeedNotificationSettings(b, userSettingIds);
            
            var tagIds = SeedTags(b, users.Select(x => x.Id));
            var typeIds = SeedExerciseTypes(b, users.Select(x => x.Id));
            SeedExerciseTypeTags(b, tagIds.Item1.ToArray(), tagIds.Item2.ToArray(), typeIds.ToArray());
        }

        private static void SeedExerciseTypeTags(ModelBuilder b, Guid[] groupIds, Guid[] tagIds, Guid[] typeIds)
        {
            var types = ExerciseTypesFactory.GetExerciseTypes().ToList();
            for (var i = 0; i < types.Count; i++)
            {
                types[i].Id = typeIds[i];
            }

            var tags = ExerciseTagGroupsFactory.GetTagGroups().ToList();
            for (var i = 0; i < tags.Count; i++)
            {
                tags[i].Id = groupIds[i];
                for (var j = 0; j < tags[i].Tags.Count; j++)
                {
                    tags[i].Tags.ToArray()[j].Id = tagIds[j];
                }
            }

            var joinValues = ExerciseTypeTagFactory.GetJoinValues(tags, types);
            foreach (var joinValue in joinValues)
            {
                joinValue.Id = Guid.NewGuid();
                b.Entity<ExerciseTypeTag>().HasData(joinValue);
            }
        }
        private static IEnumerable<Guid> SeedExerciseTypes(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            var ids = new List<Guid>();

            foreach (var userId in userIds)
            { 
                ExerciseTypesFactory.GetExerciseTypes().ToList()
                    .ForEach(type =>
                    {
                        type.Id = Guid.NewGuid();
                        type.ApplicationUserId = userId;

                        ids.Add(type.Id);
                        b.Entity<ExerciseType>().HasData(type);
                    });
            }

            return ids;
        }
        private static (IEnumerable<Guid>, IEnumerable<Guid>) SeedTags(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            var groupIds = new List<Guid>();
            var tagIds = new List<Guid>();

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

                        tagIds.Add(tag.Id);
                        b.Entity<Tag>().HasData(tag);
                    }

                    groupIds.Add(tagGroup.Id);
                    tagGroup.Tags = null; // to avoid "Navigation property is set" error because you have to ONLY connect entities through pre-set IDs
                    b.Entity<TagGroup>().HasData(tagGroup);
                }
            }

            return (groupIds, tagIds);
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
        private static IEnumerable<Guid> SeedUserSettings(ModelBuilder b, Guid[] userIds, Guid[] settingIds)
        {

            for (int i = 0; i < userIds.Length; i++)
            {
                var userSetting = new UserSetting()
                {
                    Id = settingIds[i],
                    ApplicationUserId = userIds[i]
                };

                b.Entity<UserSetting>().HasData(userSetting);
            }

            return settingIds;
        }
        private static IEnumerable<ApplicationUser> SeedUsers(ModelBuilder b)
        {
            var users = UsersFactory.GetUsers();

            b.Entity<Admin>().HasData(users.Item1);
            b.Entity<Athlete>().HasData(users.Item2);
            b.Entity<Coach>().HasData(users.Item3);
            b.Entity<SoloAthlete>().HasData(users.Item4);

            return new List<ApplicationUser>()
            {
                users.Item1,
                users.Item2,
                users.Item3,
                users.Item4
            };
        }
    }
}
