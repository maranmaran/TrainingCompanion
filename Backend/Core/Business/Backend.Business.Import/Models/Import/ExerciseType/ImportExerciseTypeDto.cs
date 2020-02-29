namespace Backend.Business.Import.Models.Import.ExerciseType
{
    public static class ImportExerciseTypeColumns
    {
        public static ImportColumn Code = new ImportColumn("Code", true);
        public static ImportColumn Name = new ImportColumn("Name", true);
        public static ImportColumn Active = new ImportColumn("Active", false);
        public static ImportColumn RequiresReps = new ImportColumn("RequiresReps", false);
        public static ImportColumn RequiresSets = new ImportColumn("RequiresSets", false);
        public static ImportColumn RequiresWeight = new ImportColumn("RequiresWeight", false);
        public static ImportColumn RequiresBodyweight = new ImportColumn("RequiresBodyweight", false);
        public static ImportColumn RequiresTime = new ImportColumn("RequiresTime", false);
        public static ImportColumn TagGroups = new ImportColumn("TagGroups", false);
        public static ImportColumn Tags = new ImportColumn("Tags", false);
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
        public string Tags { get; set; }
    }
}