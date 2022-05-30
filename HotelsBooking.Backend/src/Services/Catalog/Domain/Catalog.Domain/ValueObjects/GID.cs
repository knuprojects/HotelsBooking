using Catalog.Domain.Exceptions;
using System;

namespace Catalog.Domain.ValueObjects
{
    public sealed class GID
    {
        public Guid Value { get; set; }
        public GID(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new InvalidGuidException(value);
            }
            Value = value;
        }

        public static implicit operator Guid(GID date) => date.Value;

        public static implicit operator GID(Guid value) => new(value);
    }
}
