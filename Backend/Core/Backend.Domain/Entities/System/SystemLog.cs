using System;

namespace Backend.Domain.Entities.System
{
    public class SystemLog
    {
        public Guid Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public DateTime Date { get; set; }
    }
}