using Identity.Application.Common.Contracts;
using Identity.Application.Exceptions;
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
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordHasher _passwordHasher;

        public IdentityService(IEfRepository<User> efRepository,
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordHasher passwordHasher)
        {
            _efRepository = efRepository;
            _userRepository = userRepository;   
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
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

        public Task Register(User request)
        {
            var gid = Guid.NewGuid();

            var emailAlreadyExist = _userRepository.GetByEmailAsync(request.Email);

            if (emailAlreadyExist != null)
                throw new UserEmailAlreadyExistException(request.Email);

            var loginAlreadyExist = _userRepository.GetByLoginAsync(request.Login);

            if (loginAlreadyExist != null)
                throw new UserLoginAlreadyExistException(request.Login);

            var passwordHash = _passwordHasher.HashPassword(request.Password);

            var user = new User
            {
                GID = gid,
                Email = request.Email,
                Login = request.Login,
                Password = passwordHash
            };

            _efRepository.Add(user);

            return Task.CompletedTask;
        }
    }
}
