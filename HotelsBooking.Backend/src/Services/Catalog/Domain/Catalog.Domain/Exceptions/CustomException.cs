using System;

namespace Catalog.Domain.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message) { }
    }
}
