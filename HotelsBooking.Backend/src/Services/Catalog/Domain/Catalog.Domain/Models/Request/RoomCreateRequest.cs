using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class RoomCreateRequest
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int HotelId { get; set; }
    }
}
