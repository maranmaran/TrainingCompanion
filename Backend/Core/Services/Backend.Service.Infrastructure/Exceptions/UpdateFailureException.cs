using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class UpdateFailureException : Exception
    {
        public UpdateFailureException(string message, Exception e)
            : base($"Update failed: {message}. {e.Message}")
        {
        }
        public UpdateFailureException(string name, object key)
            : base($"Update of entity \"{name}\" ({key}) failed.")
        {
        }

        public UpdateFailureException(string name, object key, Exception e)
            : base($"Update of entity \"{name}\" ({key}) failed. {e.Message}")
        {
        }

        public UpdateFailureException(string name, object key, string message)
            : base($"Update of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
