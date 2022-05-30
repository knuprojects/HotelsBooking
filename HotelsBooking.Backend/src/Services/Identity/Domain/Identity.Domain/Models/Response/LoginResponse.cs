using System;

namespace Identity.Domain.Models.Response
{
    public sealed class LoginResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirationTime { get; set; } = DateTime.Now;
        public string RefreshToken { get; set; }
    }
}
