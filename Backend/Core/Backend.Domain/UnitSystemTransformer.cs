using System;
using Backend.Domain.Enum;

namespace Backend.Domain
{
    public static class UnitSystemTransformer
    {
        public const double MassKgLbs = 2.2046;

        /// <summary>
        /// To metric system
        /// </summary>
        public static double ToMetricSystem(this double weight, UnitSystem currentSystem)
        {
            if (currentSystem == UnitSystem.Metric)
                return weight;

            return weight.ToUnitSystem(currentSystem, UnitSystem.Metric);
        }

        /// <summary>
        /// To imperial system
        /// </summary>
        public static double ToImperialSystem(this double weight, UnitSystem currentSystem)
        {
            if (currentSystem == UnitSystem.Imperial)
                return weight;

            return weight.ToUnitSystem(currentSystem, UnitSystem.Imperial);
        }

        /// <summary>
        /// Transforms from metric system to whatever system given
        /// Whole application should save every weight in METRIC system to the database
        /// </summary>
        public static double FromMetricTo(this double weight, UnitSystem unitSystem)
        {
            return weight.ToUnitSystem(UnitSystem.Metric, unitSystem);
        }

        /// <summary>
        /// Transforms from to unit system
        /// </summary>
        private static double ToUnitSystem(this double weight, UnitSystem currentSystem, UnitSystem newSystem)
        {
            switch (currentSystem, newSystem)
            {
                case (UnitSystem.Metric, UnitSystem.Imperial):
                    return Math.Round(weight * MassKgLbs, 2);

                case (UnitSystem.Imperial, UnitSystem.Metric):
                    return Math.Round(weight / MassKgLbs, 2);

                case (UnitSystem.Metric, UnitSystem.Metric):
                case (UnitSystem.Imperial, UnitSystem.Imperial):
                    return weight;

                default:
                    throw new Exception($"Unknown unit system pair: {(currentSystem, newSystem)}");
            }
        }
    }
}
