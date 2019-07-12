using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        public NotFoundException(string name, object key, Exception e)
            : base($"Entity \"{name}\" ({key}) was not found.", e)
        {
        }

        public NotFoundException(string message, Exception e)
            : base($"{message}", e)
        {
        }
    }
}
