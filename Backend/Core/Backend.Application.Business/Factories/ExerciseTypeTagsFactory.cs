using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.User;
using System.Collections.Generic;

namespace Backend.Application.Business.Factories
{
    public static class ExercisePropertiesFactory
    {
        public static T ApplyProperties<T>(ApplicationUser user) where T : class
        {
            user.TagGroups = GetTagGroups() as ICollection<TagGroup>;

            return user as T;
        }

        public static T ApplyProperties<T>(ApplicationUser fromUser, ApplicationUser toUser) where T : class
        {
            toUser.TagGroups = fromUser.TagGroups;

            return toUser as T;
        }

        public static IEnumerable<TagGroup> GetTagGroups()
        {
            return new List<TagGroup>()
            {
                new TagGroup()
                {
                    Type = "Category",
                    Order = 0,
                    Properties = GetExerciseCategories() as ICollection<Tag>
                },
                new TagGroup()
                {
                    Type = "Bar type",
                    Order = 1,
                    Properties = GetBarTypes() as ICollection<Tag>,

                },
                new TagGroup()
                {
                    Type = "Bar position",
                    Order = 2,
                    Properties = GetBarPositions() as ICollection<Tag>,

                },
                new TagGroup()
                {
                    Type = "Equipment",
                    Order = 3,
                    Properties = GetExerciseEquipments() as ICollection<Tag>
                },
                new TagGroup()
                {
                    Type = "Grip",
                    Order = 4,
                    Properties = GetGrips() as ICollection<Tag>
                },
                new TagGroup()
                {
                    Type = "Range of motion",
                    Order = 5,
                    Properties = GetRangeOfMotions() as ICollection<Tag>
                },
                new TagGroup()
                {
                    Type = "Stance",
                    Order = 6,
                    Properties = GetStances() as ICollection<Tag>
                },
                new TagGroup()
                {
                    Type = "Tempo",
                    Order = 7,
                    Properties = GetTempos() as ICollection<Tag>
                },
            };
        }
        public static IEnumerable<Tag> GetBarTypes()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Barbell",
                    Order = 0,
                },
                new Tag()
                {
                    Value = "Dumbbell",
                    Order = 1,
                },
                new Tag()
                {
                    Value = "Saftey bar",
                    Order = 2,
                },
                new Tag()
                {
                    Value = "Cambered bar",
                    Order = 3,
                },
                new Tag()
                {
                    Value = "Neutral-grip bar",
                    Order = 4,
                },
                new Tag()
                {
                    Value = "Trap bar",
                    Order = 5,
                },
                new Tag()
                {
                    Value = "Buffalo bar",
                    Order = 6,
                },
                new Tag()
                {
                    Value = "Machine",
                    Order = 7,
                },
            };
        }
        public static IEnumerable<Tag> GetBarPositions()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Standard", Order = 0
                },
                new Tag()
                {
                    Value = "High bar", Order = 1
                },
                new Tag()
                {
                    Value = "Low bar", Order = 2
                },
                new Tag()
                {
                    Value = "Front rack", Order = 3
                },
            };
        }
        public static IEnumerable<Tag> GetExerciseCategories()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Knee dominant", Order = 0,
                },
                new Tag()
                {
                    Value = "Hip dominant", Order = 1,
                },
                new Tag()
                {
                    Value = "Horizontal push", Order = 2,
                },
                new Tag()
                {
                    Value = "Horizontal pull", Order = 3,
                },
                new Tag()
                {
                    Value = "Vertical push", Order = 4,
                },
                new Tag()
                {
                    Value = "Vertical pull", Order = 5,
                },
                new Tag()
                {
                    Value = "Other", Order = 6,
                },
            };
        }
        public static IEnumerable<Tag> GetGrips()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Snatch grip", Order = 0,
                },
                new Tag()
                {
                    Value = "Reverse grip", Order = 1,
                },
                new Tag()
                {
                    Value = "Close grip", Order = 2,
                },
                new Tag()
                {
                    Value = "Wide grip", Order = 3,
                },
            };
        }
        public static IEnumerable<Tag> GetExerciseEquipments()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Belt", Order = 0,
                },
                new Tag()
                {
                    Value = "Knee sleeves", Order = 1,
                },
                new Tag()
                {
                    Value = "Knee wraps", Order = 2,
                },
                new Tag()
                {
                    Value = "Slingshot", Order = 3,
                },
                new Tag()
                {
                    Value = "Breifs", Order = 4,
                },
                new Tag()
                {
                    Value = "Squat suit", Order = 5,
                },
                new Tag()
                {
                    Value = "Bench shirt", Order = 6,
                },
                new Tag()
                {
                    Value = "Deadlift suit", Order = 7,
                },
                new Tag()
                {
                    Value = "Wrist wraps", Order = 7,
                },
            };
        }
        public static IEnumerable<Tag> GetLoadAccomodations()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Light band", Order = 0,
                },
                new Tag()
                {
                    Value = "Average band", Order = 1,
                },
                new Tag()
                {
                    Value = "Strong band", Order = 2,
                },
                new Tag()
                {
                    Value = "Chains", Order = 3,
                },
                new Tag()
                {
                    Value = "Reverse light band", Order = 4,
                },
                new Tag()
                {
                    Value = "Reverse average band", Order = 5,
                },
                new Tag()
                {
                    Value = "Reverse strong band", Order = 6,
                },
            };
        }
        public static IEnumerable<Tag> GetRangeOfMotions()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Standard", Order = 0,
                },
                new Tag()
                {
                    Value = "Box", Order = 1,
                },
                new Tag()
                {
                    Value = "Towel", Order = 2,
                },
                new Tag()
                {
                    Value = "Low pin", Order = 3,
                },
                new Tag()
                {
                    Value = "Middle pin", Order = 4,
                },
                new Tag()
                {
                    Value = "High pin", Order = 5,
                },
                new Tag()
                {
                    Value = "Two inch deficit", Order = 6,
                },
                new Tag()
                {
                    Value = "Half board", Order = 7,
                },
                new Tag()
                {
                    Value = "Two board", Order = 8,
                },
                new Tag()
                {
                    Value = "Three board", Order = 9,
                },
                new Tag()
                {
                    Value = "Four board", Order = 10,
                },
                new Tag()
                {
                    Value = "Five board", Order = 11,
                },
                new Tag()
                {
                    Value = "Towel - 8 cm ", Order = 12,
                },
            };
        }
        public static IEnumerable<Tag> GetStances()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Standard", Order = 0,
                },
                new Tag()
                {
                    Value = "Narrow", Order = 1,
                },
                new Tag()
                {
                    Value = "Wide", Order = 2,
                },
                new Tag()
                {
                    Value = "Sumo", Order = 3,
                },
                new Tag()
                {
                    Value = "Conventional", Order = 4,
                },
                new Tag()
                {
                    Value = "Stiff legged", Order = 5,
                },
                new Tag()
                {
                    Value = "Feet up", Order = 6,
                },
            };
        }
        public static IEnumerable<Tag> GetTempos()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Value = "Standard", Order = 0,
                },
                new Tag()
                {
                    Value = "Touch and go", Order = 1,
                },
                new Tag()
                {
                    Value = "Pause - 2 count", Order = 2,
                },
                new Tag()
                {
                    Value = "Pause - 3 count", Order = 3,
                },
                new Tag()
                {
                    Value = "Pause - 5 count", Order = 4,
                },
                new Tag()
                {
                    Value = "Pause - 7 count", Order = 5,
                },
                new Tag()
                {
                    Value = "Tempo - 600", Order = 6,
                },
                new Tag()
                {
                    Value = "Tempo - 320", Order = 7,
                },
                new Tag()
                {
                    Value = "Tempo - 530", Order = 8,
                },
                new Tag()
                {
                    Value = "Tempo - 303", Order = 9,
                },
                new Tag()
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
