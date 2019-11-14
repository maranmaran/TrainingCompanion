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
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Backend.Persistance
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder b)
        {
            var users = SeedUsers(b);
            var userSettingIds = SeedUserSettings(b, users.Select(x => x.Id).ToArray(), users.Select(x=>x.UserSettingId).ToArray());
            SeedNotificationSettings(b, userSettingIds);
            
            var tagIds = SeedTags(b, users.Select(x => x.Id));
            var typeIds = SeedExerciseTypes(b, users.Select(x => x.Id));
            SeedExerciseTypeTags(b, tagIds.Item1.ToArray(), tagIds.Item2.ToArray(), typeIds.ToArray(), users.Count());
        }

        // JOIN TABLE FOR EXERCISE TYPE - TAGS (Properties)
        private static void SeedExerciseTypeTags(ModelBuilder b, Guid[] tagGroupIds, Guid[] tagIds, Guid[] typeIds, int userCount)
        {
            var types = ExerciseTypesFactory.GetExerciseTypes().ToList();
            var tagGroups = ExerciseTagGroupsFactory.GetTagGroups().ToList();
            
            // foreach user
            while(userCount > 0) 
            {
                // assign type id
                for (var i = 0; i < types.Count; i++)
                {
                    types[i].Id = typeIds[i];
                }

                // assign all tag group and tag ids
                for (var i = 0; i < tagGroups.Count; i++)
                {
                    tagGroups[i].Id = tagGroupIds[i];
                    var tagsArr = tagGroups[i].Tags.ToArray();
                
                    for (var j = 0; j < tagsArr.Length; j++)
                    {
                        tagsArr[j].Id = tagIds[j];
                    }

                    tagGroups[i].Tags = tagsArr;
                }

                // make join entities
                var joinValues = ExerciseTypeTagFactory.GetJoinValues(tagGroups, types);
                foreach (var joinValue in joinValues)
                {
                    joinValue.Id = Guid.NewGuid();
                    b.Entity<ExerciseTypeTag>().HasData(joinValue);
                }

                // reset
                userCount--;
                typeIds = typeIds.Skip(types.Count).ToArray();
                tagGroupIds = tagGroupIds.Skip(tagGroups.Count).ToArray();
                tagIds = tagIds.Skip(tagGroups.Aggregate(0, (acc, source) => source.Tags.Count)).ToArray();
            }

        }
        
        // EXERCISE TYPES
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

        // TAG GROUPS AND TAGS 
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

        // USERS
        private static void SeedNotificationSettings(ModelBuilder b, IEnumerable<Guid> userSettingIds)
        {
            foreach (var userSettingId in userSettingIds)
            {

                var values = EnumFactory.SeedEnum<NotificationType, NotificationSetting>((value) => new NotificationSetting() 
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
            var users = UsersSeeder.GetUsers();

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
