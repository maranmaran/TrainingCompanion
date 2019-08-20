using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.User;
using System.Collections.Generic;

namespace Backend.Application.Business.Factories
{
    public static class ExercisePropertiesFactory
    {
        public static T ApplyProperties<T>(ApplicationUser user) where T : class
        {
            user.ExercisePropertyTypes = GetExercisePropertyTypes() as ICollection<ExercisePropertyType>;

            return user as T;
        }

        public static T ApplyProperties<T>(ApplicationUser fromUser, ApplicationUser toUser) where T : class
        {
            toUser.ExercisePropertyTypes = fromUser.ExercisePropertyTypes;

            return toUser as T;
        }

        public static IEnumerable<ExercisePropertyType> GetExercisePropertyTypes()
        {
            return new List<ExercisePropertyType>()
            {
                new ExercisePropertyType()
                {
                    Type = "Category",
                    Order = 0,
                    Properties = GetExerciseCategories() as ICollection<ExerciseProperty>
                },
                new ExercisePropertyType()
                {
                    Type = "Bar type",
                    Order = 1,
                    Properties = GetBarTypes() as ICollection<ExerciseProperty>,
               
                },
                new ExercisePropertyType()
                {
                    Type = "Bar position",
                    Order = 2,
                    Properties = GetBarPositions() as ICollection<ExerciseProperty>,

                },
                new ExercisePropertyType()
                {
                    Type = "Equipment",
                    Order = 3,
                    Properties = GetExerciseEquipments() as ICollection<ExerciseProperty>
                },
                new ExercisePropertyType()
                {
                    Type = "Grip",
                    Order = 4,
                    Properties = GetGrips() as ICollection<ExerciseProperty>
                },
                new ExercisePropertyType()
                {
                    Type = "Range of motion",
                    Order = 5,
                    Properties = GetRangeOfMotions() as ICollection<ExerciseProperty>
                },
                new ExercisePropertyType()
                {
                    Type = "Stance",
                    Order = 6,
                    Properties = GetStances() as ICollection<ExerciseProperty>
                },
                new ExercisePropertyType()
                {
                    Type = "Tempo",
                    Order = 7,
                    Properties = GetTempos() as ICollection<ExerciseProperty>
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetBarTypes()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Barbell",
                    Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Dumbbell",
                    Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Saftey bar",
                    Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Cambered bar",
                    Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Neutral-grip bar",
                    Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Trap bar",
                    Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Buffalo bar",
                    Order = 6,
                },
                new ExerciseProperty()
                {
                    Value = "Machine",
                    Order = 7,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetBarPositions()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Standard", Order = 0
                },
                new ExerciseProperty()
                {
                    Value = "High bar", Order = 1
                },
                new ExerciseProperty()
                {
                    Value = "Low bar", Order = 2
                },
                new ExerciseProperty()
                {
                    Value = "Front rack", Order = 3
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetExerciseCategories()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Knee dominant", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Hip dominant", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Horizontal push", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Horizontal pull", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Vertical push", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Vertical pull", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Other", Order = 6,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetGrips()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Snatch grip", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Reverse grip", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Close grip", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Wide grip", Order = 3,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetExerciseEquipments()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Belt", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Knee wraps", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Slingshot", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Breifs", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Squat suit", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Bench shirt", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Deadlift suit", Order = 6,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetLoadAccomodations()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Light band", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Average band", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Strong band", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Chains", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Reverse light band", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Reverse average band", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Reverse strong band", Order = 6,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetRangeOfMotions()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Standard", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Box", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Towel", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Low pin", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Middle pin", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "High pin", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Two inch deficit", Order = 6,
                },
                new ExerciseProperty()
                {
                    Value = "Half board", Order = 7,
                },
                new ExerciseProperty()
                {
                    Value = "Two board", Order = 8,
                },
                new ExerciseProperty()
                {
                    Value = "Three board", Order = 9,
                },
                new ExerciseProperty()
                {
                    Value = "Four board", Order = 10,
                },
                new ExerciseProperty()
                {
                    Value = "Five board", Order = 11,
                },
                new ExerciseProperty()
                {
                    Value = "Towel - 8 cm ", Order = 12,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetStances()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Standard", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Narrow", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Wide", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Sumo", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Conventional", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Stiff legged", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Feet up", Order = 6,
                },
            };
        }
        private static IEnumerable<ExerciseProperty> GetTempos()
        {
            return new List<ExerciseProperty>()
            {
                new ExerciseProperty()
                {
                    Value = "Standard", Order = 0,
                },
                new ExerciseProperty()
                {
                    Value = "Touch and go", Order = 1,
                },
                new ExerciseProperty()
                {
                    Value = "Pause - 2 count", Order = 2,
                },
                new ExerciseProperty()
                {
                    Value = "Pause - 3 count", Order = 3,
                },
                new ExerciseProperty()
                {
                    Value = "Pause - 5 count", Order = 4,
                },
                new ExerciseProperty()
                {
                    Value = "Pause - 7 count", Order = 5,
                },
                new ExerciseProperty()
                {
                    Value = "Tempo - 600", Order = 6,
                },
                new ExerciseProperty()
                {
                    Value = "Tempo - 320", Order = 7,
                },
                new ExerciseProperty()
                {
                    Value = "Tempo - 530", Order = 8,
                },
                new ExerciseProperty()
                {
                    Value = "Tempo - 303", Order = 9,
                },
                new ExerciseProperty()
                {
                    Value = "Tempo - 003", Order = 10,
                },
            };
        }

        //public enum BarType
        //{
        //    Barbell,
        //    Dumbbell,
        //    SafteyBar,
        //    CamberedBar,
        //    NeutralGripBar,
        //    TrapBar,
        //    BuffaloBar,
        //    Machine,
        //}

        //public enum BarPosition
        //{
        //    Standard,
        //    HighBar,
        //    LowBar,
        //    FrontRack,
        //}

        //public enum ExerciseTypeCategory
        //{
        //    KneeDominant,
        //    HipDominant,
        //    HorizontalPush,
        //    VerticalPush,
        //    VerticalPull,
        //    HorizontalPull,
        //    Other,
        //}

        //public enum Grip
        //{
        //    SnatchGrip,
        //    ReverseGrip,
        //    CloseGrip,
        //    WideGrip,
        //}

        //public enum Kit
        //{
        //    Belt,
        //    KneeWraps,
        //    Slingshot,
        //    Breifs,
        //    Suits,
        //    SquatSuit,
        //    BenchShirt,
        //    DeadliftSuit
        //}

        //public enum LoadAccomodation
        //{
        //    LightBand,
        //    AverageBand,
        //    StrongBand,
        //    ReverseMiniStand,
        //    ReverseLightBand,
        //    ReverseAverageBand,
        //    ReverseStrongBand
        //}

        //public enum RangeOfMotion
        //{
        //    Standard,
        //    Box,
        //    Towel,
        //    LowPin,
        //    MiddlePin,
        //    HighPin,
        //    TwoInchDeficit,
        //    HalfBoard,
        //    OneBoard,
        //    TwoBoard,
        //    ThreeBoard,
        //    FourBoard,
        //    FiveBoard,
        //    Towel8Cm
        //}

        //public enum Stance
        //{
        //    Standard,
        //    CloseStance,
        //    WideStance,
        //    Sumo,
        //    Conventional,
        //    StiffLegged,
        //    FeetUp,
        //}
        //public enum Tempo
        //{
        //    Standard,

        //    TouchAndGo,

        //    Pause2Ct,
        //    Pause3Ct,
        //    Pause5Ct,
        //    Pause7Ct,

        //    Tempo600, 
        //    Tempo320, 
        //    Tempo530, 
        //    Tempo303, 
        //    Tempo003, 
        //}
    }
}
