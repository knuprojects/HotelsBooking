using System;

namespace Identity.Domain.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
