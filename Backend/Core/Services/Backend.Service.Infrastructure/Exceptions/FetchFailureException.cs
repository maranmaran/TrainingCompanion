using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class FetchFailureException : Exception
    {
        public FetchFailureException(string message, Exception e)
            : base($"Fetch failed: {message}. {e.Message}")
        {
        }

        public FetchFailureException(string name, object key)
            : base($"Fetch of entity \"{name}\" ({key}) failed.")
        {
        }

        public FetchFailureException(string name, object key, Exception e)
            : base($"Fetch of entity \"{name}\" ({key}) failed. {e.Message}")
        {
        }

        public FetchFailureException(string name, object key, string message)
            : base($"Fetch of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
