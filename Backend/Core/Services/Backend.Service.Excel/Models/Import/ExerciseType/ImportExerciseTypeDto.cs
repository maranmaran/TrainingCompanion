using System;
using Backend.Domain.Entities.TrainingLog;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Backend.Service.Excel.Models.Import.ExerciseType
{
    public static class ImportExerciseTypeColumns
    {
        public static (string ColumnName, bool Required) Code = ("Code", true);
        public static (string ColumnName, bool Required) Name = ("Name", true);
        public static (string ColumnName, bool Required) Active = ("Active", false);
        public static (string ColumnName, bool Required) RequiresReps = ("RequiresReps", false);
        public static (string ColumnName, bool Required) RequiresSets = ("RequiresSets", false);
        public static (string ColumnName, bool Required) RequiresWeight = ("RequiresWeight", false);
        public static (string ColumnName, bool Required) RequiresBodyweight = ("RequiresBodyweight", false);
        public static (string ColumnName, bool Required) RequiresTime = ("RequiresTime", false);
        public static (string ColumnName, bool Required) TagGroups = ("TagGroups", false);
        public static (string ColumnName, bool Required) Tags = ("Tags", false);
    }

    public class ImportExerciseTypeDto
    {
        [Column("Code")]
        public string Code { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Active")]
        public bool Active { get; set; }
        
        [Column("RequiresReps")]
        public bool RequiresReps { get; set; }
        
        [Column("RequiresSets")]
        public bool RequiresSets { get; set; }
        
        [Column("RequiresWeight")]
        public bool RequiresWeight { get; set; }
        
        [Column("RequiresBodyweight")]
        public bool RequiresBodyweight { get; set; }

        [Column("RequiresTime")]
        public bool RequiresTime { get; set; }

        [Column("TagGroups")]
        public string TagGroups { get; set; }

        [Column("Tags")]
        public string Tags{ get; set; }

    }
}
