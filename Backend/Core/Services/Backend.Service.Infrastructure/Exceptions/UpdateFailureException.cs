using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class UpdateFailureException : ExtendedException
    {
        public UpdateFailureException(string name, Exception e)
            : base($"Updating of entity \"{name}\" failed.", e)
        {
        }

        public UpdateFailureException(string name, Guid id, Exception e)
            : base($"Updating of entity \"{name}\" with id: {id} failed.", e)
        {
        }

        public UpdateFailureException(string name, Guid id, string message)
            : base($"Updating of entity \"{name}\" with id: {id} failed. {message}")
        {
        }
    }
}
