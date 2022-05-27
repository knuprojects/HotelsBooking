using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class RoomCreateRequest
    {
        [Required]
        public Number Number { get; set; }
        [Required]
        public Floor Floor { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public Price Price { get; set; }
        [Required]
        public Hotel HotelGID { get; set; }
    }
}
