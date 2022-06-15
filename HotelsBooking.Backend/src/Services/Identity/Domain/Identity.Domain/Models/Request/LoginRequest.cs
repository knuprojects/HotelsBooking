using Identity.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models.Request
{
    public sealed class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
