namespace Identity.Application.Exceptions
{
    public class InvalidCurrentPasswordException : CustomException
    {
        public string Password { get; }

        public InvalidCurrentPasswordException(string password) : base($"Invalid current password {password}.")
        {
            Password = password;
        }
    }
}
