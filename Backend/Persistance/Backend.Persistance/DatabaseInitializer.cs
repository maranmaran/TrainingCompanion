using Backend.Common.Extensions;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Domain.Factories;
using Backend.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tag = Backend.Domain.Entities.Exercises.Tag;

namespace Backend.Persistance
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder b)
        {
            var users = SeedUsers(b);
            var userSettingIds = SeedUserSettings(b, users.Select(x => x.Id).ToArray(), users.Select(x => x.UserSettingId).ToArray());
            SeedNotificationSettings(b, userSettingIds);

            //var tagGroupDictionary = SeedTags(b, users.Select(x => x.Id));
            //var exerciseTypeDictionary = SeedExerciseTypes(b, users.Select(x => x.Id));
            //SeedExerciseTypeTags(b, tagGroupDictionary, exerciseTypeDictionary, users.Select(x => x.Id).ToList());
        }

        // JOIN TABLE FOR EXERCISE TYPE - TAGS (Properties)
        private static void SeedExerciseTypeTags(
            ModelBuilder b,
            IDictionary<Guid, IEnumerable<TagGroup>> tagGroupDict,
            IDictionary<Guid, IEnumerable<ExerciseType>> exerciseTypeDict,
            IEnumerable<Guid> users)
        {
            // foreach user
            foreach (var userId in users)
            {
                var tagGroups = (tagGroupDict[userId] ?? throw new InvalidOperationException()).ToList();
                var types = (exerciseTypeDict[userId] ?? throw new InvalidOperationException()).ToList();

                // make join entities
                var joinValues = ExerciseTypeTagFactory.GetJoinValues(tagGroups, types);
                foreach (var joinValue in joinValues)
                {
                    joinValue.Id = Guid.NewGuid();
                    b.Entity<ExerciseTypeTag>().HasData(joinValue);
                }
            }
        }

        // EXERCISE TYPES
        private static IDictionary<Guid, IEnumerable<ExerciseType>> SeedExerciseTypes(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            var dict = new Dictionary<Guid, IEnumerable<ExerciseType>>();

            foreach (var userId in userIds)
            {
                var exerciseTypes = ExerciseTypesFactory.GetExerciseTypes().ToList();
                exerciseTypes.ForEach(type =>
                {
                    type.Id = Guid.NewGuid();
                    type.ApplicationUserId = userId;

                    b.Entity<ExerciseType>().HasData(type);
                });

                dict.Add(userId, exerciseTypes.ToList());
            }

            return dict;
        }

        // TAG GROUPS AND TAGS
        private static IDictionary<Guid, IEnumerable<TagGroup>> SeedTags(ModelBuilder b, IEnumerable<Guid> userIds)
        {
            var dict = new Dictionary<Guid, IEnumerable<TagGroup>>();

            foreach (var userId in userIds)
            {
                var tagGroups = ExerciseTagGroupsFactory.GetTagGroups().ToList();

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
                }

                dict.Add(userId, tagGroups.Clone()); // clone the list

                tagGroups.ForEach(tg =>
                {
                    tg.Tags = null; // to avoid "Navigation property is set" error because you have to ONLY connect entities through pre-set IDs
                    b.Entity<TagGroup>().HasData(tg);
                });
            }

            return dict;
        }

        // USERS
        private static void SeedNotificationSettings(ModelBuilder b, IEnumerable<Guid> userSettingIds)
        {
            // missing last character
            // we'll use index of setting to fill that in
            // Other characters will be removed by counter
            var startGuid = "71691ddc-039f-4606-b614-ff4a19516cd";
            var counter = 0;
            foreach (var userSettingId in userSettingIds)
            {
                if (counter % 10 == 0)
                {
                    startGuid = startGuid.Remove(startGuid.Length - 1);
                }
                var values = EnumFactory.SeedEnum<NotificationType, NotificationSetting>((value, index) => new NotificationSetting()
                {
                    Id = Guid.Parse(startGuid + counter + index),
                    NotificationType = value,
                    UserSettingId = userSettingId
                }).ToList();

                counter++;
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