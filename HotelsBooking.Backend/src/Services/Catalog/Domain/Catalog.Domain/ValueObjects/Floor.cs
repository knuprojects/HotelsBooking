using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class Floor
    {
        public int Value { get; set; }
        public Floor(int value)
        {
            if (value < 0 || value > 500)
                throw new InvalidFloorException(value);

            Value = value;
        }
        public static implicit operator Floor(int value) => new(value);

        public static implicit operator int(Floor floor) => floor.Value;
    }
}
