namespace Identity.Domain.Exceptions
{
    public sealed class InvalidPasswordException : CustomException
    {
        public string Password { get; }

        public InvalidPasswordException(string password) : base($"Password: {password} is invalid")
        {
            Password = password;
        }
    }
}
