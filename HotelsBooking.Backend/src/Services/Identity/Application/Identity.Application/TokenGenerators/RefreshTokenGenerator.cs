using Identity.Domain.Models.Configuration;
using System;

namespace Identity.Application.TokenGenerators
{
    public class RefreshTokenGenerator
    {
        private readonly AuthConfiguration _configuration;
        private readonly JwtTokenGenerator _tokenGenerator;

        public RefreshTokenGenerator(AuthConfiguration configuration, JwtTokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        public string GenerateToken()
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.RefreshTokenExpirationMinutes);

            return _tokenGenerator.GenerateToken(
                _configuration.RefreshTokenSecret,
                _configuration.Issuer,
                _configuration.Audience,
                expirationTime);
        }
    }
}
