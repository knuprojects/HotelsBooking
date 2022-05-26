using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Price
    {
        public decimal Value { get; }
        public Price(decimal value)
        {
            if (value < 0)
                throw new InvalidPriceException(value);

            Value = value;
        }

        public static implicit operator Price(decimal price) => new(price);

        public static implicit operator decimal(Price price) => price.Value;
    }
}
