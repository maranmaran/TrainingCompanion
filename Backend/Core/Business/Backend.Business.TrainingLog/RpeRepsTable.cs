using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Business.TrainingLog
{
    public class RpeTableColumn
    {
        public double Reps { get; set; }
        public double Rpe { get; set; }

        public RpeTableColumn(int reps, double rpe)
        {
            Reps = reps;
            Rpe = rpe;
        }
    }

    public static class RpeRepsTable
    {

        public static double CalculateLiftMax(double reps, double rpe, double weight)
        {

            if (rpe >= 6 && reps <= 10)
            {
                var key = PercentageTable.Keys.SingleOrDefault(x => x.Reps.Equals(reps) && x.Rpe.Equals(rpe));

                if (key != null)
                {
                    var percentageValue = PercentageTable[key];

                    return Math.Round((weight * 100) / percentageValue, 1);
                }
            }

            return Math.Round(OneRepMaxCalculator.EpleyFormula(reps, weight, rpe), 1);
        }

        public static IDictionary<RpeTableColumn, double> PercentageTable = new Dictionary<RpeTableColumn, double>()
        {
            { new RpeTableColumn(1, 10), 100 },
            { new RpeTableColumn(1, 9.5), 98 },
            { new RpeTableColumn(1, 9), 96 },
            { new RpeTableColumn(1, 8.5), 94 },
            { new RpeTableColumn(1, 8), 92 },
            { new RpeTableColumn(1, 7.5), 91 },
            { new RpeTableColumn(1, 7), 89 },
            { new RpeTableColumn(1, 6.5), 88 },
            { new RpeTableColumn(1, 6), 86 },

            { new RpeTableColumn(2, 10), 96 },
            { new RpeTableColumn(2, 9.5), 94 },
            { new RpeTableColumn(2, 9), 92 },
            { new RpeTableColumn(2, 8.5), 91 },
            { new RpeTableColumn(2, 8), 89 },
            { new RpeTableColumn(2, 7.5), 88 },
            { new RpeTableColumn(2, 7), 86 },
            { new RpeTableColumn(2, 6.5), 85 },
            { new RpeTableColumn(2, 6), 84 },

            { new RpeTableColumn(3, 10), 92 },
            { new RpeTableColumn(3, 9.5), 91 },
            { new RpeTableColumn(3, 9), 89 },
            { new RpeTableColumn(3, 8.5), 88 },
            { new RpeTableColumn(3, 8), 86 },
            { new RpeTableColumn(3, 7.5), 85 },
            { new RpeTableColumn(3, 7), 84 },
            { new RpeTableColumn(3, 6.5), 82 },
            { new RpeTableColumn(3, 6), 81 },

            { new RpeTableColumn(4, 10), 89 },
            { new RpeTableColumn(4, 9.5), 88 },
            { new RpeTableColumn(4, 9), 86 },
            { new RpeTableColumn(4, 8.5), 85 },
            { new RpeTableColumn(4, 8), 84 },
            { new RpeTableColumn(4, 7.5), 82 },
            { new RpeTableColumn(4, 7), 81 },
            { new RpeTableColumn(4, 6.5), 80 },
            { new RpeTableColumn(4, 6), 79 },

            { new RpeTableColumn(5, 10), 86 },
            { new RpeTableColumn(5, 9.5), 85 },
            { new RpeTableColumn(5, 9), 84 },
            { new RpeTableColumn(5, 8.5), 82 },
            { new RpeTableColumn(5, 8), 81 },
            { new RpeTableColumn(5, 7.5), 80 },
            { new RpeTableColumn(5, 7), 79 },
            { new RpeTableColumn(5, 6.5), 77 },
            { new RpeTableColumn(5, 6), 76 },

            { new RpeTableColumn(6, 10), 84 },
            { new RpeTableColumn(6, 9.5), 82 },
            { new RpeTableColumn(6, 9), 81 },
            { new RpeTableColumn(6, 8.5), 80 },
            { new RpeTableColumn(6, 8), 79 },
            { new RpeTableColumn(6, 7.5), 77 },
            { new RpeTableColumn(6, 7), 76 },
            { new RpeTableColumn(6, 6.5), 75 },
            { new RpeTableColumn(6, 6), 74 },

            { new RpeTableColumn(7, 10), 81 },
            { new RpeTableColumn(7, 9.5), 80 },
            { new RpeTableColumn(7, 9), 79 },
            { new RpeTableColumn(7, 8.5), 77 },
            { new RpeTableColumn(7, 8), 76 },
            { new RpeTableColumn(7, 7.5), 75 },
            { new RpeTableColumn(7, 7), 74 },
            { new RpeTableColumn(7, 6.5), 72 },
            { new RpeTableColumn(7, 6), 71 },

            { new RpeTableColumn(8, 10), 79 },
            { new RpeTableColumn(8, 9.5), 77 },
            { new RpeTableColumn(8, 9), 76 },
            { new RpeTableColumn(8, 8.5), 75 },
            { new RpeTableColumn(8, 8), 74 },
            { new RpeTableColumn(8, 7.5), 72 },
            { new RpeTableColumn(8, 7), 71 },
            { new RpeTableColumn(8, 6.5), 69 },
            { new RpeTableColumn(8, 6), 68 },

            { new RpeTableColumn(9, 10), 76 },
            { new RpeTableColumn(9, 9.5), 75 },
            { new RpeTableColumn(9, 9), 74 },
            { new RpeTableColumn(9, 8.5), 72 },
            { new RpeTableColumn(9, 8), 71 },
            { new RpeTableColumn(9, 7.5), 69 },
            { new RpeTableColumn(9, 7), 68 },
            { new RpeTableColumn(9, 6.5), 67 },
            { new RpeTableColumn(9, 6), 65 },

            { new RpeTableColumn(10, 10), 74 },
            { new RpeTableColumn(10, 9.5), 72 },
            { new RpeTableColumn(10, 9), 71 },
            { new RpeTableColumn(10, 8.5), 69 },
            { new RpeTableColumn(10, 8), 68 },
            { new RpeTableColumn(10, 7.5), 67 },
            { new RpeTableColumn(10, 7), 65 },
            { new RpeTableColumn(10, 6.5), 64 },
            { new RpeTableColumn(10, 6), 62 },
        };
    }
}
