using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Description
    {
        public string Value { get; set; }
        public Description(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length is > 256 or < 12)
                throw new InvalidDescriptionException(value);

            Value = value;
        }

        public static implicit operator Description(string value) => value is null ? null : new Description(value);

        public static implicit operator string(Description value) => value.Value;
        public override string ToString() => Value;
    }
}
