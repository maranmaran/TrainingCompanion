using System;
using Backend.Library.Excel.Models;

namespace Backend.Business.Import
{
    public class TrainingImportDto
    {
        [Column("Date", true)]
        public DateTime Date { get; set; }

        [Column("ExerciseCode", true)]
        public string Code { get; set; }

        [Column("Weight", false)]
        public double Weight { get; set; }

        [Column("Reps", false)]
        public double Reps { get; set; }

        [Column("Time", false)]
        public TimeSpan Time { get; set; }

        [Column("Rpe", false)]
        public double Rpe { get; set; }
    }
}