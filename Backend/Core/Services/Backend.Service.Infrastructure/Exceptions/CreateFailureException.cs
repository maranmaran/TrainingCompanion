using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class CreateFailureException : Exception
    {
        public CreateFailureException(string message, Exception e)
            : base($"Create failed: {message}. {e.Message}")
        {
        }

        public CreateFailureException(string name, object key)
            : base($"Creation of entity \"{name}\" ({key}) failed.")
        {
        }

        public CreateFailureException(string name, object key, Exception e)
            : base($"Creation of entity \"{name}\" ({key}) failed. {e.Message}")
        {
        }

        public CreateFailureException(string name, object key, string message)
            : base($"Creation of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
