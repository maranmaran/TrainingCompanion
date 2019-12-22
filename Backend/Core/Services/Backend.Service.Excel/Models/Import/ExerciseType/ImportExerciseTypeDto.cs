using System;
using Backend.Domain.Entities.TrainingLog;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Backend.Service.Excel.Models.Import.ExerciseType
{
    public class ImportExerciseTypeColumns
    {
        public (string ColumnName, bool Required) Code = ("Code", true);
        public (string ColumnName, bool Required) Name = ("Name", true);
        public (string ColumnName, bool Required) Active = ("Active", false);
        public (string ColumnName, bool Required) RequiresReps = ("RequiresReps", false);
        public (string ColumnName, bool Required) RequiresSets = ("RequiresSets", false);
        public (string ColumnName, bool Required) RequiresWeight = ("RequiresWeight", false);
        public (string ColumnName, bool Required) RequiresBodyweight = ("RequiresBodyweight", false);
        public (string ColumnName, bool Required) RequiresTime = ("RequiresTime", false);
    }

    public class ImportExerciseTypeDto
    {
        [Column(nameof(ImportExerciseTypeColumns.Code.ColumnName))]
        public string Code { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.Name.ColumnName))]
        public string Name { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.Active.ColumnName))]
        public bool Active { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.RequiresReps.ColumnName))]
        public bool RequiresReps { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.RequiresSets.ColumnName))]
        public bool RequiresSets { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.RequiresWeight.ColumnName))]
        public bool RequiresWeight { get; set; }
        
        [Column(nameof(ImportExerciseTypeColumns.RequiresBodyweight.ColumnName))]
        public bool RequiresBodyweight { get; set; }

        [Column(nameof(ImportExerciseTypeColumns.RequiresTime.ColumnName))]
        public bool RequiresTime { get; set; }

    }
}
