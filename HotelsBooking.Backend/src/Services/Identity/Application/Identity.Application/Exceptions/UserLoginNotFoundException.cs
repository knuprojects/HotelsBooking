namespace Identity.Application.Exceptions
{
    public class UserLoginNotFoundException : CustomException
    {
        public string Login { get; }

        public UserLoginNotFoundException(string login) : base($"User with this login {login} not exist.")
        {
            Login = login;
        }
    }
}
