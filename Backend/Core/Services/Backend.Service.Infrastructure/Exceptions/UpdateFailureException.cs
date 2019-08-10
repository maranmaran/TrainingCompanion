using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class UpdateFailureException : Exception
    {
        public UpdateFailureException(string name, Exception e)
            : base($"Updating of entity \"{name}\" failed. {e.Message}")
        {
        }

        public UpdateFailureException(string name, Guid id, Exception e)
            : base($"Updating of entity \"{name}\" with id: {id} failed. {e.Message}")
        {
        }

        public UpdateFailureException(string name, Guid id, string message)
            : base($"Updating of entity \"{name}\" with id: {id} failed. {message}")
        {
        }
    }
}
