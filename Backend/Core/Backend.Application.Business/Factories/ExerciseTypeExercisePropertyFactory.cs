using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Application.Business.Factories
{
    public static class ExerciseTypeExercisePropertyFactory
    {
        public static ICollection<ExerciseTypeExerciseProperty> JoinExerciseTypesAndProperties(ApplicationUser user)
        {
            return GetJoinValues(user.ExercisePropertyTypes.ToList(), user.ExerciseTypes.ToList()) as ICollection<ExerciseTypeExerciseProperty>;
        }

        private static IEnumerable<ExerciseTypeExerciseProperty> GetJoinValues(List<ExercisePropertyType> propertyTypes, List<ExerciseType> exerciseTypes)
        {
            return new List<ExerciseTypeExerciseProperty>()
            {

                // SQUAT
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Bar type").Properties.First(x => x.Value == "Barbell"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Bar position").Properties.First(x => x.Value == "Low bar"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Category").Properties.First(x => x.Value == "Knee dominant"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Equipment").Properties.First(x => x.Value == "Belt"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Equipment").Properties.First(x => x.Value == "Knee sleeves"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Stance").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = false
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Tempo").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = false
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Range of motion").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Squat - competition"),
                    Show = false
                },

                // BENCH PRESS
             new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Bar type").Properties.First(x => x.Value == "Barbell"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Category").Properties.First(x => x.Value == "Horizontal push"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Grip").Properties.First(x => x.Value == "Wide grip"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Equipment").Properties.First(x => x.Value == "Wrist wraps"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Range of motion").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = false
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Tempo").Properties.First(x => x.Value == "Pause - 3 count"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Bench press - competition"),
                    Show = true
                },

                // DEADLIFT 
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Bar type").Properties.First(x => x.Value == "Barbell"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Category").Properties.First(x => x.Value == "Hip dominant"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Equipment").Properties.First(x => x.Value == "Belt"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = true
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Range of motion").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = false
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Stance").Properties.First(x => x.Value == "Sumo"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = false
                },
                new ExerciseTypeExerciseProperty()
                {
                    ExerciseProperty = propertyTypes.First(x => x.Type == "Tempo").Properties.First(x => x.Value == "Standard"),
                    ExerciseType = exerciseTypes.First(x => x.Name == "Deadlift - competition"),
                    Show = false
                },
            };
        }
    }
}
