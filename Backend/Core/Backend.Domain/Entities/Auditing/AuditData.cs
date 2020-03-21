using System;

namespace Backend.Domain.Entities.Auditing
{
    public class AuditData<T> where T : class
    {
        public string Table { get; set; }
        public string Action { get; set; }
        public Guid PrimaryKey { get; set; }
        public T Entity { get; set; }
        public T ColumnValues { get; set; }
        public bool Valid { get; set; }
    }
}