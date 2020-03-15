using System;

namespace Backend.Domain.Entities.Auditing
{
    public class AuditRecord
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public string EntityType { get; set; }
        public string Table { get; set; }
        public string PrimaryKey { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
    }
}
