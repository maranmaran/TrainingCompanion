using System;

namespace Backend.Infrastructure.Exceptions
{
    public class CreateFailureException : ExtendedException
    {
        public CreateFailureException(string name, Exception e)
            : base($"Creation of entity \"{name}\" failed.", e)
        {
        }
    }
}