using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Number
    {
        public int Value { get; }
        public Number(int value)
        {
            if (value < 0 || value > 500)
                throw new InvalidNumberException(value);

            Value = value;
        }
        public static implicit operator Number(int value) => new(value);

        public static implicit operator int(Number number) => number.Value;
    }
}
