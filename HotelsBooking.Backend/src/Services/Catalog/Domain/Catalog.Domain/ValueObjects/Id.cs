using Catalog.Domain.Exceptions;
using System;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Id
    {
        public int Value { get; set; }
        public Id(int value)
        {
            if(value == 0)
            {
                throw new InvalidIdException(value);
            }
            Value = value;
        }

        public static implicit operator int(Id date) => date.Value;

        public static implicit operator Id(int value) => new(value);
    }
}
