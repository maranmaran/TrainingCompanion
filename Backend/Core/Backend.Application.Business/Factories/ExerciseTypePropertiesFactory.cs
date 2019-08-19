using Backend.Domain.Entities.User;
using System.Collections.Generic;
using Backend.Domain.Entities.ExerciseType;

namespace Backend.Application.Business.Factories
{
    public static class ExerciseTypePropertiesFactory
    {
        public static T ApplyProperties<T>(ApplicationUser user) where T : class
        {
            user.Stances = GetStances() as ICollection<Stance>;
            user.BarPositions = GetBarPositions() as ICollection<BarPosition>;
            user.BarTypes = GetBarTypes() as ICollection<BarType>;
            user.ExerciseEquipments = GetExerciseEquipments() as ICollection<Equipment>;
            user.ExerciseCategories = GetExerciseCategories() as ICollection<Category>;
            user.LoadAccomodations = GetLoadAccomodations() as ICollection<LoadAccomodation>;
            user.Grips = GetGrips() as ICollection<Grip>;
            user.Tempos = GetTempos() as ICollection<Tempo>;
            user.RangeOfMotions = GetRangeOfMotions() as ICollection<RangeOfMotion>;

            return user as T;
        }

        public static T ApplyProperties<T>(ApplicationUser fromUser, ApplicationUser toUser) where T : class
        {
            toUser.Stances = fromUser.Stances;
            toUser.BarPositions = fromUser.BarPositions;
            toUser.BarTypes = fromUser.BarTypes;
            toUser.ExerciseEquipments = fromUser.ExerciseEquipments;
            toUser.ExerciseCategories = fromUser.ExerciseCategories;
            toUser.LoadAccomodations = fromUser.LoadAccomodations;
            toUser.Grips = fromUser.Grips;
            toUser.Tempos = fromUser.Tempos;
            toUser.RangeOfMotions = fromUser.RangeOfMotions;

            return toUser as T;
        }

        public static IEnumerable<BarType> GetBarTypes()
        {
            return new List<BarType>()
            {
                new BarType()
                {
                    Value = "Barbell",
                    Order = 0,
                },
                new BarType()
                {
                    Value = "Dumbbell",
                    Order = 1,
                },
                new BarType()
                {
                    Value = "Saftey bar",
                    Order = 2,
                },
                new BarType()
                {
                    Value = "Cambered bar",
                    Order = 3,
                },
                new BarType()
                {
                    Value = "Neutral-grip bar",
                    Order = 4,
                },
                new BarType()
                {
                    Value = "Trap bar",
                    Order = 5,
                },
                new BarType()
                {
                    Value = "Buffalo bar",
                    Order = 6,
                },
                new BarType()
                {
                    Value = "Machine",
                    Order = 7,
                },
            };
        }
        public static IEnumerable<BarPosition> GetBarPositions()
        {
            return new List<BarPosition>()
            {
                new BarPosition()
                {
                    Value = "Standard", Order = 0
                },
                new BarPosition()
                {
                    Value = "High bar", Order = 1
                },
                new BarPosition()
                {
                    Value = "Low bar", Order = 2
                },
                new BarPosition()
                {
                    Value = "Front rack", Order = 3
                },
            };
        }
        public static IEnumerable<Category> GetExerciseCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Value = "Knee dominant", Order = 0,
                },
                new Category()
                {
                    Value = "Hip dominant", Order = 1,
                },
                new Category()
                {
                    Value = "Horizontal push", Order = 2,
                },
                new Category()
                {
                    Value = "Horizontal pull", Order = 3,
                },
                new Category()
                {
                    Value = "Vertical push", Order = 4,
                },
                new Category()
                {
                    Value = "Vertical pull", Order = 5,
                },
                new Category()
                {
                    Value = "Other", Order = 6,
                },
            };
        }
        public static IEnumerable<Grip> GetGrips()
        {
            return new List<Grip>()
            {
                new Grip()
                {
                    Value = "Snatch grip", Order = 0,
                },
                new Grip()
                {
                    Value = "Reverse grip", Order = 1,
                },
                new Grip()
                {
                    Value = "Close grip", Order = 2,
                },
                new Grip()
                {
                    Value = "Wide grip", Order = 3,
                },
            };
        }
        public static IEnumerable<Equipment> GetExerciseEquipments()
        {
            return new List<Equipment>()
            {
                new Equipment()
                {
                    Value = "Belt", Order = 0,
                },
                new Equipment()
                {
                    Value = "Knee wraps", Order = 1,
                },
                new Equipment()
                {
                    Value = "Slingshot", Order = 2,
                },
                new Equipment()
                {
                    Value = "Breifs", Order = 3,
                },
                new Equipment()
                {
                    Value = "Squat suit", Order = 4,
                },
                new Equipment()
                {
                    Value = "Bench shirt", Order = 5,
                },
                new Equipment()
                {
                    Value = "Deadlift suit", Order = 6,
                },
            };
        }
        public static IEnumerable<LoadAccomodation> GetLoadAccomodations()
        {
            return new List<LoadAccomodation>()
            {
                new LoadAccomodation()
                {
                    Value = "Light band", Order = 0,
                },
                new LoadAccomodation()
                {
                    Value = "Average band", Order = 1,
                },
                new LoadAccomodation()
                {
                    Value = "Strong band", Order = 2,
                },
                new LoadAccomodation()
                {
                    Value = "Chains", Order = 3,
                },
                new LoadAccomodation()
                {
                    Value = "Reverse light band", Order = 4,
                },
                new LoadAccomodation()
                {
                    Value = "Reverse average band", Order = 5,
                },
                new LoadAccomodation()
                {
                    Value = "Reverse strong band", Order = 6,
                },
            };
        }
        public static IEnumerable<RangeOfMotion> GetRangeOfMotions()
        {
            return new List<RangeOfMotion>()
            {
                new RangeOfMotion()
                {
                    Value = "Standard", Order = 0,
                },
                new RangeOfMotion()
                {
                    Value = "Box", Order = 1,
                },
                new RangeOfMotion()
                {
                    Value = "Towel", Order = 2,
                },
                new RangeOfMotion()
                {
                    Value = "Low pin", Order = 3,
                },
                new RangeOfMotion()
                {
                    Value = "Middle pin", Order = 4,
                },
                new RangeOfMotion()
                {
                    Value = "High pin", Order = 5,
                },
                new RangeOfMotion()
                {
                    Value = "Two inch deficit", Order = 6,
                },
                new RangeOfMotion()
                {
                    Value = "Half board", Order = 7,
                },
                new RangeOfMotion()
                {
                    Value = "Two board", Order = 8,
                },
                new RangeOfMotion()
                {
                    Value = "Three board", Order = 9,
                },
                new RangeOfMotion()
                {
                    Value = "Four board", Order = 10,
                },
                new RangeOfMotion()
                {
                    Value = "Five board", Order = 11,
                },
                new RangeOfMotion()
                {
                    Value = "Towel - 8 cm ", Order = 12,
                },
            };
        }
        public static IEnumerable<Stance> GetStances()
        {
            return new List<Stance>()
            {
                new Stance()
                {
                    Value = "Standard", Order = 0,
                },
                new Stance()
                {
                    Value = "Narrow", Order = 1,
                },
                new Stance()
                {
                    Value = "Wide", Order = 2,
                },
                new Stance()
                {
                    Value = "Sumo", Order = 3,
                },
                new Stance()
                {
                    Value = "Conventional", Order = 4,
                },
                new Stance()
                {
                    Value = "Stiff legged", Order = 5,
                },
                new Stance()
                {
                    Value = "Feet up", Order = 6,
                },
            };
        }
        public static IEnumerable<Tempo> GetTempos()
        {
            return new List<Tempo>()
            {
                new Tempo()
                {
                    Value = "Standard", Order = 0,
                },
                new Tempo()
                {
                    Value = "Touch and go", Order = 1,
                },
                new Tempo()
                {
                    Value = "Pause - 2 count", Order = 2,
                },
                new Tempo()
                {
                    Value = "Pause - 3 count", Order = 3,
                },
                new Tempo()
                {
                    Value = "Pause - 5 count", Order = 4,
                },
                new Tempo()
                {
                    Value = "Pause - 7 count", Order = 5,
                },
                new Tempo()
                {
                    Value = "Tempo - 6", Order = 6,
                },
                new Tempo()
                {
                    Value = "Tempo - 32", Order = 7,
                },
                new Tempo()
                {
                    Value = "Tempo - 53", Order = 8,
                },
                new Tempo()
                {
                    Value = "Tempo - 30", Order = 9,
                },
                new Tempo()
                {
                    Value = "Tempo - 00", Order = 19,
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
