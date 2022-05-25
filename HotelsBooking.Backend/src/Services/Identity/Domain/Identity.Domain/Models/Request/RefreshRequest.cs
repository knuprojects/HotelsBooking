using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models.Request
{
    public sealed class RefreshRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
