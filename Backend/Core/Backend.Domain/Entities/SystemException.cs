using System;

namespace Backend.Domain.Entities
{
    public class SystemException
    {
        public Guid Id { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public DateTime Date { get; set; }
    }
}
