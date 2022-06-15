using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Models.Request
{
    public sealed class RoomDeleteRequest
    {
        [Required]
        public int GID { get; set; }
    }
}
