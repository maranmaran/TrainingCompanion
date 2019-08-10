using System;

namespace Backend.Service.Infrastructure.Exceptions
{
    public class CreateFailureException : Exception
    {
        public CreateFailureException(string name, Exception e)
            : base($"Creation of entity \"{name}\" failed. {e.Message}")
        {
        }
    }
}
