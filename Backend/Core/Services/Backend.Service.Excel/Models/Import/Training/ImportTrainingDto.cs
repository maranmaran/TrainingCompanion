using System;

namespace Backend.Service.Excel.Models.Import.Training
{
    public enum ImportTrainingColumns
    {
        Date,
        Exercise,
        Weight,
        Reps,
        Rpe,
        Time
    }

    public class ImportTrainingDto
    {
        [Column(nameof(ImportTrainingColumns.Date))]
        public DateTime Date { get; set; }

        [Column(nameof(ImportTrainingColumns.Exercise))]
        public string Exercise { get; set; }

        [Column(nameof(ImportTrainingColumns.Weight))]
        public double Weight { get; set; }

        [Column(nameof(ImportTrainingColumns.Reps))]
        public double Reps { get; set; }

        [Column(nameof(ImportTrainingColumns.Time))]
        public TimeSpan Time { get; set; }

        [Column(nameof(ImportTrainingColumns.Rpe))]
        public double Rpe { get; set; }
    }
}
