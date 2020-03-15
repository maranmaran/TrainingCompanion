using System.Collections.Generic;
using System.Linq;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.User;

namespace Backend.Domain.Factories
{
    public static class ExerciseTypeTagFactory
    {
        public static ICollection<ExerciseTypeTag> JoinExerciseTypesAndProperties(ApplicationUser user)
        {
            return GetJoinValues(user.TagGroups.ToList(), user.ExerciseTypes.ToList()) as ICollection<ExerciseTypeTag>;
        }

        public static IEnumerable<ExerciseTypeTag> GetJoinValues(List<TagGroup> tagGroups, List<ExerciseType> exerciseTypes)
        {
            return new List<ExerciseTypeTag>()
            {
                // SQUAT
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Bar position").Tags.First(x => x.Value == "Low bar").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Category").Tags.First(x => x.Value == "Knee dominant").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Belt").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Knee sleeves").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Stance").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = false
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = false
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Squat - competition").Id,
                    Show = false
                },

                // BENCH PRESS
             new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Category").Tags.First(x => x.Value == "Horizontal push").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Grip").Tags.First(x => x.Value == "Wide grip").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Wrist wraps").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = false
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Pause - 3 count").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Bench press - competition").Id,
                    Show = true
                },

                // DEADLIFT
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Category").Tags.First(x => x.Value == "Hip dominant").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Belt").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = true
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = false
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Stance").Tags.First(x => x.Value == "Sumo").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = false
                },
                new ExerciseTypeTag()
                {
                    TagId = tagGroups.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Standard").Id,
                    ExerciseTypeId = exerciseTypes.First(x => x.Name == "Deadlift - competition").Id,
                    Show = false
                },
            };
        }
    }
}