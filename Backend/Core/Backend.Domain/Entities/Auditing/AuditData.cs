namespace Backend.Domain.Entities.Auditing
{
    public class AuditData<T> where T : class
    {
        public string Table { get; set; }
        public string Action { get; set; }
        public AuditDataPK PrimaryKey { get; set; }
        public T Entity { get; set; }
        public T ColumnValues { get; set; }
        public bool Valid { get; set; }
    }

    public class AuditDataPK
    {
        public string Id { get; set; }
    }
}