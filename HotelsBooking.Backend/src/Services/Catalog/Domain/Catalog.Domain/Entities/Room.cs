using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities
{
    public class Room : BaseEntity
    {
        public Number Number { get; private set; }
        public Floor Floor { get; private set; }
        public RoomType RoomType { get; private set; }
        public Price Price { get; private set; }
        public Hotel HotelGID { get; set; }
    }
}
