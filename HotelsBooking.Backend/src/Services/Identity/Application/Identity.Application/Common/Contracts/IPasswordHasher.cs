namespace Identity.Application.Common.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string user);

        bool VerifyPassword(string password, string passwordHash);
    }
}
