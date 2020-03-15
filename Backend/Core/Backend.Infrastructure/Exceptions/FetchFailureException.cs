using System;

namespace Backend.Infrastructure.Exceptions
{
    public class FetchFailureException : ExtendedException
    {
        public FetchFailureException(string name, Exception e)
            : base($"Fetching of entity \"{name}\" failed.", e)
        {
        }

        public FetchFailureException(string name, Guid id, Exception e)
            : base($"Fetching of entity \"{name}\" with id: {id} failed.", e)
        {
        }
    }
}