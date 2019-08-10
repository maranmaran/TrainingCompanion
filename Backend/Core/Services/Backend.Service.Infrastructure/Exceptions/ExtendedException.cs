using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class ExtendedException : Exception
    {
        public int Status { get; set; }
        public new string Message { get; set; }

        public Exception Exception { get; set; }

        public ExtendedException(int status, string message, Exception exception) : base(message, exception.InnerException)
        {
            Status = status;
            Message = message;
            Exception = exception;
        }

        public ExtendedException(int status, string message) : base(message)
        {
            Status = status;
            Message = message;
        }
    }
}
