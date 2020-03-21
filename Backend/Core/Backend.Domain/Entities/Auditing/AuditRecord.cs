using Newtonsoft.Json;
using System;

namespace Backend.Domain.Entities.Auditing
{
    public class AuditRecord
    {
        public Guid Id { get; set; }

        public string Data { get; set; }
        public AuditData<T> GetData<T>() where T : class
        {
            return JsonConvert.DeserializeObject<AuditData<T>>(string.IsNullOrEmpty(Data) ? "{}" : Data);
        }

        public string EntityType { get; set; }
        public string Table { get; set; }
        public string PrimaryKey { get; set; }
        public string Action { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
