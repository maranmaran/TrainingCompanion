using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Exception e)
            : base($"Entity \"{name}\" not found. {e.Message}")
        {
        }

        public NotFoundException(string name, Guid id, Exception e)
            : base($"Entity \"{name}\" with id: {id} not found. {e.Message}")
        {
        }

        public NotFoundException(string name, Guid id)
            : base($"Entity \"{name}\" with id: {id} not found.")
        {
        }

        public NotFoundException(string name, string message)
            : base($"Entity \"{name}\" not found. {message}")
        {
        }

        public NotFoundException(string name, string message, Exception e)
            : base($"Entity \"{name}\" not found. {message}")
        {
        }
    }
}
