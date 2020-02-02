using Backend.Domain.Enum;
using System;

namespace Backend.Application.Business.Code
{
    public static class Transformer
    {
        public const double MassKgLbs = 2.2046;

        public static double TransformWeight(this double weight, UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.Metric: // this is by default
                    return ToMetric(weight);
                case UnitSystem.Imperial:
                    return ToImperial(weight);
                default:
                    throw new Exception("No Unit system like the one specified");
            }
        }

        private static double ToImperial(double number)
        {
            return Math.Round(number * MassKgLbs, 2);
        }

        private static double ToMetric(double number)
        {
            return Math.Round(number, 2);
        }
    }
}
