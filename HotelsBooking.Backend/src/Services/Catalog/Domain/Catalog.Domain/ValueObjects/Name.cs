using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Name
    {
        public string Value { get; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 128 or < 3)
                throw new InvalidNameException(value);

            Value = value;
        }

        public static implicit operator Name(string value) => value is null ? null : new Name(value);

        public static implicit operator string(Name value) => value.Value;
        public override string ToString() => Value;
    }
}
