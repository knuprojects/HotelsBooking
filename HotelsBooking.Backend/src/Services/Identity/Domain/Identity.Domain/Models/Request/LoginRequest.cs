using Identity.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Models.Request
{
    public sealed class LoginRequest
    {
        [Required]
        public Email Email { get; set; }

        [Required]
        public Password Password { get; set; }
    }
}
