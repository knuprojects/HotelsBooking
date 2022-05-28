using Identity.Application.Common.Contracts;
using Identity.Application.TokenGenerators;
using Identity.Dal.Common.Contracts;
using Identity.Domain.Entites;
using Identity.Domain.Models.Request;
using Identity.Domain.Models.Response;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Common.Services
{
    public class IdentityService : IIdentityRepository
    {
        private readonly IEfRepository<User> _efRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public IdentityService(IEfRepository<User> efRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _efRepository = efRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginResponse> Authenticate(User user)
        {
            AccessToken accessToken = _accessTokenGenerator.GenerateToken(user);
            string refreshToken = _refreshTokenGenerator.GenerateToken();

            RefreshToken refreshTokenDTO = new RefreshToken()
            {
                Token = refreshToken,
                UserId = user.GID
            };

            await _refreshTokenRepository.Create(refreshTokenDTO);

            return new LoginResponse()
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                RefreshToken = refreshToken
            };
        }

        public Task Register(RegistrationRequest request)
        {
            var gid = Guid.NewGuid();

            var user = new User
            {
                GID = gid,
                Email = request.Email,
                Login = request.Login,
                Password = request.Password
            };

            _efRepository.Add(user);

            return Task.CompletedTask;
        }
    }
}
