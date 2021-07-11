using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.User;
using System.Collections.Generic;

namespace Backend.Domain.Factories
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
                },
                new ExerciseType()
                {
                    Name = "Bench press - competition",
                },
                new ExerciseType()
                {
                    Name = "Deadlift - competition",
                },
            };
        }
    }
}