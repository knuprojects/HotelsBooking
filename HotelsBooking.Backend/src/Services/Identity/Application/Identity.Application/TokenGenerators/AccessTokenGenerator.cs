using Identity.Domain.Entites;
using Identity.Domain.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Application.TokenGenerators
{
    public class AccessTokenGenerator
    {
        private readonly AuthConfiguration _configuration;
        private readonly JwtTokenGenerator _tokenGenerator;

        public AccessTokenGenerator(AuthConfiguration configuration, JwtTokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        public AccessToken GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("GID", user.GID.ToString()),
                new Claim("Role", user.Role.ToString())
            };

            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpirationMinutes);

            string value = _tokenGenerator.GenerateToken(
                _configuration.AccessTokenSecret,
                _configuration.Issuer,
                _configuration.Audience,
                expirationTime,
                claims);

            return new AccessToken()
            {
                Value = value,
                ExpirationTime = expirationTime
            };
        }
    }
}
