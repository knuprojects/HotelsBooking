namespace Identity.Application.Common.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
