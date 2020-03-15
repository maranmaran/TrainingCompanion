using System;

namespace Backend.Infrastructure.Exceptions
{
    public class NotFoundException : ExtendedException
    {
        public NotFoundException(string name, Exception e)
            : base($"Entity \"{name}\" not found.", e)
        {
        }

        public NotFoundException(string name, Guid id, Exception e)
            : base($"Entity \"{name}\" with id: {id} not found.", e)
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
            : base($"Entity \"{name}\" not found. {message}", e)
        {
        }
    }
}