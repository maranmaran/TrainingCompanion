using Backend.Library.Excel.Models;

namespace Backend.Business.Import
{
    public class ExerciseTypeImportDto
    {
        [Column("Code", true)]
        public string Code { get; set; }

        [Column("Name", true)]
        public string Name { get; set; }

        [Column("Active", false)]
        public bool Active { get; set; }

        [Column("RequiresReps", false)]
        public bool RequiresReps { get; set; }

        [Column("RequiresSets", false)]
        public bool RequiresSets { get; set; }

        [Column("RequiresWeight", false)]
        public bool RequiresWeight { get; set; }

        [Column("RequiresBodyweight", false)]
        public bool RequiresBodyweight { get; set; }

        [Column("RequiresTime", false)]
        public bool RequiresTime { get; set; }

        [Column("TagGroups", false)]
        public string TagGroups { get; set; }

        [Column("Tags", false)]
        public string Tags { get; set; }
    }
}