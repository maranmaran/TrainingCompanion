using System.Collections.Generic;
using Backend.Domain.Entities.User;

namespace Backend.Service.Excel.Models
{
    public class ExportTrainingContainer
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ExportTraining> Trainings { get; set; }
        public IEnumerable<string> Columns { get; set; }
        
    }
}