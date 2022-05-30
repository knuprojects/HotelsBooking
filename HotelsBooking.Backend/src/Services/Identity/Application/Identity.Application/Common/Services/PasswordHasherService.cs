using Identity.Application.Common.Contracts;
using Identity.Domain.Entites;
using Identity.Domain.ValueObjects;

namespace Identity.Application.Common.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
