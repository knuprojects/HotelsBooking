using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class HotelDeleteRequest
    {
        [Required]
        public Guid GID { get; set; }
    }
}
