using System;

namespace Backend.Business.TrainingLog.Code
{
    public static class OneRepMaxCalculator
    {
        public static double EpleyFormula(double reps, double weight, double rpe)
        {
            return weight * (1 + (reps + 10 - rpe) / 30) * 0.967742;
        }

        public static double Brzycki(double reps, double weight)
        {
            return weight * (36 / (37 - (double)reps));
        }

        public static double McGlothin(double reps, double weight)
        {
            return (100 * weight) / (101.3 - 2.67123 * reps);
        }

        public static double Lombardi(double reps, double weight)
        {
            return Math.Pow(reps * weight, 0.1);
        }

        public static double Mayhew(double reps, double weight)
        {
            return 100 * weight / (52.2 + 41.9 * Math.Pow(Math.E, -0.055 * reps));
        }

        public static double OConner(double reps, double weight)
        {
            return weight * (1 + reps / 40);
        }

        public static double Wathan(double reps, double weight)
        {
            return 100 * weight / (48.8 + 53.8 * Math.Pow(Math.E, -0.075 * reps));
        }
    }
}