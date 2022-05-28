namespace Identity.Application.Exceptions
{
    public class UserLoginAlreadyExistException : CustomException
    {
        public string Login { get; }

        public UserLoginAlreadyExistException(string login) : base($"User with this login {login} already exist.")
        {
            Login = login;
        }
    }
}
