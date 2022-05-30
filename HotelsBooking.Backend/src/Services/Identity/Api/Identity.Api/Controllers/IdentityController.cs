using Identity.Application.Common.Contracts;
using Identity.Application.TokenValidator;
using Identity.Domain.Entites;
using Identity.Domain.Models.Request;
using Identity.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityRepository _authRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RefreshTokenValidator _refreshTokenValidator;

        public IdentityController(IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IIdentityRepository authRepository,
            IRefreshTokenRepository refreshTokenRepository,
            RefreshTokenValidator refreshTokenValidator)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _refreshTokenValidator = refreshTokenValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationUser = new User()
            {
                Email = registerRequest.Email,
                Login = registerRequest.Login,
                Password = registerRequest.Password
            };

            var result = _authRepository.Register(registrationUser);

            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _userRepository.GetByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            bool isCorrectPassword = _passwordHasher.VerifyPassword(loginRequest.Password, user.Password);
            if (!isCorrectPassword)
            {
                return Unauthorized();
            }

            LoginResponse response = await _authRepository.Authenticate(user);
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest refreshRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValidRefreshToken = _refreshTokenValidator.Validate(refreshRequest.RefreshToken);
            if (!isValidRefreshToken)
            {
                return BadRequest(ModelState);
            }

            RefreshToken refreshTokenDTO = await _refreshTokenRepository.GetByToken(refreshRequest.RefreshToken);
            if (refreshTokenDTO == null)
            {
                return BadRequest(ModelState);
            }
            await _refreshTokenRepository.Delete(refreshTokenDTO.GID);
            User user = await _userRepository.GetById(refreshTokenDTO.UserId);
            if (user == null)
            {
                return NotFound();
            }
            LoginResponse response = await _authRepository.Authenticate(user);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            string rawUserId = HttpContext.User.FindFirstValue("GID");

            if (!Guid.TryParse(rawUserId, out Guid userId))
            {
                return Unauthorized();
            }

            await _refreshTokenRepository.DeleteAll(userId);

            return NoContent();
        }
    }
}
