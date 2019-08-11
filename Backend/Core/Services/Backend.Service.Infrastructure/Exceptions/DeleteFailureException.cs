using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class DeleteFailureException : ExtendedException
    {
        public DeleteFailureException(string name, Exception e)
            : base($"Deletion of entity \"{name}\" failed.", e)
        {
        }

        public DeleteFailureException(string name, Guid id, Exception e)
            : base($"Deletion of entity \"{name}\" with id: {id} failed.", e)
        {
        }
    }
}
