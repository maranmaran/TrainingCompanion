using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Application.Business.Factories
{
    public static class ExerciseTypesFactory
    {
        public static T ApplyExercises<T>(ApplicationUser user) where T : class
        {
            user.ExerciseTypes = GetExerciseTypes() as ICollection<ExerciseType>;

            return user as T;
        }

        public static IEnumerable<ExerciseType> GetExerciseTypes()
        {
            return new List<ExerciseType>()
            {
                new ExerciseType()
                {
                    Name = "Squat - competition",
                    //Tags = new List<ExerciseTypeTag>()
                    //{
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Bar position").Tags.First(x => x.Value == "Low bar"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Category").Tags.First(x => x.Value == "Knee dominant"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Belt"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Knee sleeves"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Stance").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //}
                },
                new ExerciseType()
                {
                    Name = "Bench press - competition",
                    //Tags = new List<ExerciseTypeTag>()
                    //{
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Category").Tags.First(x => x.Value == "Horizontal push"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Grip").Tags.First(x => x.Value == "Wide grip"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Wrist wraps"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Pause - 3 count"),
                    //        Show = true
                    //    },
                    //}
                },
                new ExerciseType()
                {
                    Name = "Deadlift - competition",
                    //Tags = new List<ExerciseTypeTag>()
                    //{
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Bar type").Tags.First(x => x.Value == "Barbell"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Category").Tags.First(x => x.Value == "Hip dominant"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Equipment").Tags.First(x => x.Value == "Belt"),
                    //        Show = true
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Range of motion").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Stance").Tags.First(x => x.Value == "Sumo"),
                    //        Show = false
                    //    },
                    //    new ExerciseTypeTag()
                    //    {
                    //        Tag = types.First(x => x.Type == "Tempo").Tags.First(x => x.Value == "Standard"),
                    //        Show = false
                    //    },
                    //}
                },
            };
        }

    }
}
