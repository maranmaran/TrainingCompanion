using System;

namespace Backend.Business.Import.Models.Training
{
    public class ImportTrainingColumns
    {
        public (string ColumnName, bool Required) Date = ("Date", true);
        public (string ColumnName, bool Required) ExerciseCode = ("ExerciseCode", true);
        public (string ColumnName, bool Required) Weight = ("Weight", false);
        public (string ColumnName, bool Required) Reps = ("Reps", false);
        public (string ColumnName, bool Required) Rpe = ("Rpe", false);
        public (string ColumnName, bool Required) Time = ("Time", false);
    }

    public class ImportTrainingDto
    {
        [Column(nameof(ImportTrainingColumns.Date.ColumnName))]
        public DateTime Date { get; set; }

        [Column(nameof(ImportTrainingColumns.ExerciseCode.ColumnName))]
        public string Code { get; set; }

        [Column(nameof(ImportTrainingColumns.Weight.ColumnName))]
        public double Weight { get; set; }

        [Column(nameof(ImportTrainingColumns.Reps.ColumnName))]
        public double Reps { get; set; }

        [Column(nameof(ImportTrainingColumns.Time.ColumnName))]
        public TimeSpan Time { get; set; }

        [Column(nameof(ImportTrainingColumns.Rpe.ColumnName))]
        public double Rpe { get; set; }
    }
}