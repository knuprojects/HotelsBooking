namespace Identity.Domain.Exceptions
{
    public sealed class InvalidLoginException : CustomException
    {
       public string Login { get; }

        public InvalidLoginException(string login) : base($"Login: '{login}' is invalid.")
        {
            Login = login;
        }
    }
}
