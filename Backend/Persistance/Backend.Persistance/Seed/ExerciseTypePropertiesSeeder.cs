using Backend.Domain.Entities.ExerciseType.Properties;
using Backend.Domain.Entities.User;
using System.Collections.Generic;

namespace Backend.Persistance.Seed
{
    public class ExerciseTypePropertiesSeeder
    {
        public static ApplicationUser SeedUser(ApplicationUser user)
        {
            user.Stances = StanceSeed.Seed() as ICollection<Stance>;
            user.BarPositions = BarPositionSeed.Seed() as ICollection<BarPosition>;
            user.BarTypes = BarTypeSeed.Seed() as ICollection<BarType>;
            user.ExerciseEquipments = ExerciseEquipmentSeed.Seed() as ICollection<ExerciseEquipment>;
            user.ExerciseCategories = ExerciseCategorySeed.Seed() as ICollection<ExerciseCategory>;
            user.LoadAccomodations = LoadAccomodationSeed.Seed() as ICollection<LoadAccomodation>;
            user.Grips = GripSeed.Seed() as ICollection<Grip>;
            user.Tempos = TempoSeed.Seed() as ICollection<Tempo>;
            user.RangeOfMotions = RangeOfMotionSeed.Seed() as ICollection<RangeOfMotion>;

            return user;
        }
    }
    public static class BarTypeSeed
    {
        public static IEnumerable<BarType> Seed()
        {
            return new List<BarType>()
            {
                new BarType()
                {
                    Value = "Barbell"
                }
            };
        }
    }
    public static class BarPositionSeed
    {
        public static IEnumerable<BarPosition> Seed()
        {
            return new List<BarPosition>();
        }
    }
    public static class ExerciseCategorySeed
    {
        public static IEnumerable<ExerciseCategory> Seed()
        {
            return new List<ExerciseCategory>();
        }
    }
    public static class GripSeed
    {
        public static IEnumerable<Grip> Seed()
        {
            return new List<Grip>();
        }
    }
    public static class ExerciseEquipmentSeed
    {
        public static IEnumerable<ExerciseEquipment> Seed()
        {
            return new List<ExerciseEquipment>();
        }
    }
    public static class LoadAccomodationSeed
    {
        public static IEnumerable<LoadAccomodation> Seed()
        {
            return new List<LoadAccomodation>();
        }
    }
    public static class RangeOfMotionSeed
    {
        public static IEnumerable<RangeOfMotion> Seed()
        {
            return new List<RangeOfMotion>();
        }
    }
    public static class StanceSeed
    {
        public static IEnumerable<Stance> Seed()
        {
            return new List<Stance>();
        }
    }
    public static class TempoSeed
    {
        public static IEnumerable<Tempo> Seed()
        {
            return new List<Tempo>();
        }
    }
}
