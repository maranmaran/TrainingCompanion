using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;

namespace Backend.Business.TrainingLog.Code
{
    public static class SetExtensions
    {
        /// <summary>
        /// Modifies given set and transforms it's parameters between unit systems and adds
        /// parameters like volume and projected maximum
        /// </summary>
        /// <param name="set"></param>
        public static void TransformSet(this Set set, ExerciseType type, UserSetting settings)
        {
            if (type.RequiresWeight && !type.RequiresBodyweight)
            {
                set.Weight = set.Weight.ToMetricSystem(settings.UnitSystem); // make sure everything going in from weight is METRIC!
            }

            // update additional properties
            if (type.RequiresReps && type.RequiresSets)
            {

                if (type.RequiresWeight)
                {
                    set.Volume = set.Reps * set.Weight;
                }
            }

            if (settings.UseRpeSystem && type.RequiresReps && type.RequiresSets && (type.RequiresWeight || type.RequiresBodyweight))
            {
                set.ProjectedMax = RpeRepsTable.CalculateLiftMax(set.Reps, settings.RpeSystem == RpeSystem.Rpe ? set.Rpe : 10 - set.Rir, set.Weight);
            }
        }

    }
}