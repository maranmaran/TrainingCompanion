using System;
using System.Collections.Generic;

namespace Backend.Service.Excel.Models.Export.Training
{
    public class ExportTrainingDto
    {
        public DateTime? Date { get; set; }
        public IEnumerable<ExportExerciseDto> Exercises { get; set; }
    }

    public class ExportExerciseDto
    {
        public string Exercise { get; set; }
        public string ExerciseTags { get; set; }
        public IEnumerable<ExportSetDto> Sets { get; set; }
    }

    public class ExportSetDto
    {
        public double Weight { get; set; }
        public double Reps { get; set; }
        public TimeSpan Time { get; set; }
        public double Rpe { get; set; }
        public double Volume { get; set; }
    }
}
