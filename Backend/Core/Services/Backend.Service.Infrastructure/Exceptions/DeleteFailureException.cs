using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, Exception e)
            : base($"Deletion of entity \"{name}\" failed. {e.Message}")
        {
        }

        public DeleteFailureException(string name, Guid id, Exception e)
            : base($"Deletion of entity \"{name}\" with id: {id} failed. {e.Message}")
        {
        }
    }
}
