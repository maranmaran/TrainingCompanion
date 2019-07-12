using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string message, Exception e)
            : base($"Delete failed: {message}. {e.Message}")
        {
        }

        public DeleteFailureException(string name, object key)
            : base($"Deletion of entity \"{name}\" ({key}) failed.")
        {
        }

        public DeleteFailureException(string name, object key, Exception e)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {e.Message}")
        {
        }

        public DeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
