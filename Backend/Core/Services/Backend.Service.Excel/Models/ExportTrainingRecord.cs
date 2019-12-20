using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Enum;

namespace Backend.Service.Excel.Models
{
    public class ExportTraining
    {
        public DateTime? Date { get; set; }
        public IEnumerable<ExportTrainingExercise> Exercises { get; set; }
    }

    public class ExportTrainingExercise
    {
        public string Exercise { get; set; }
        public string ExerciseTags { get; set; }
        public IEnumerable<ExportTrainingSet> Sets { get; set; }
    }

    public class ExportTrainingSet
    {
        public double Weight { get; set; }
        public double Reps { get; set; }
        public TimeSpan Time { get; set; }
        public double Rpe { get; set; }
        public double Volume { get; set; }
    }
}
