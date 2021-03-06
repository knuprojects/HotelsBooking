using Catalog.Domain.ValueObjects;
using System;

namespace Catalog.Domain.Entities
{
    public class Room : BaseEntity
    {
        public Number Number { get; set; }
        public Floor Floor { get; set; }
        public RoomType RoomType { get; set; }
        public Price Price { get; set; }
        public int HotelId { get; set; }
    }
}
