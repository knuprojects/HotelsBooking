namespace Identity.Domain.Models.Configuration
{
    public sealed class AuthConfiguration
    {
        public string AccessTokenSecret { get; set; }
        public float AccessTokenExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string RefreshTokenSecret { get; set; }
        public float RefreshTokenExpirationMinutes { get; set; }
    }
}
