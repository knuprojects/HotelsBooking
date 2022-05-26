namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidFloorException : CustomException
    {
        public int Floor { get; }
        public InvalidFloorException(int floor) : base($"Floor: '{floor}' is invalid.")
        {
            Floor = floor;
        }
    }
}
