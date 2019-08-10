using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class FetchFailureException : Exception
    {
        public FetchFailureException(string name, Exception e)
            : base($"Fetching of entity \"{name}\" failed. {e.Message}")
        {
        }

        public FetchFailureException(string name, Guid id, Exception e)
            : base($"Fetching of entity \"{name}\" failed. {e.Message}")
        {
        }
    }
}
