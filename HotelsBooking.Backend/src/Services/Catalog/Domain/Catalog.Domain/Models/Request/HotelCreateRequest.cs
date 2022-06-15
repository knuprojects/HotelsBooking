using Catalog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class HotelCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
    }
}
