using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class City
    {
        public string Value { get; }
        public City(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 128 or < 3)
                throw new InvalidCityException(value);

            Value = value;
        }

        public static implicit operator City(string value) => value is null ? null : new City(value);

        public static implicit operator string(City value) => value.Value;
        public override string ToString() => Value;
    }
}
