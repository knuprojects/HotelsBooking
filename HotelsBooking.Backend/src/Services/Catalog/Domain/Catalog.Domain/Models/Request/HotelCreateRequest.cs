using Catalog.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class HotelCreateRequest
    {
        [Required]
        public Name Name { get; set; }
        [Required]
        public Description Description { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public PhotoUrl PhotoUrl { get; set; }
    }
}
