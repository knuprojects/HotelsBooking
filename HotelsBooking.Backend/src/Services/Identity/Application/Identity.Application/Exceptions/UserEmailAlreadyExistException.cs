namespace Identity.Application.Exceptions
{
    public class UserEmailAlreadyExistException : CustomException
    {
        public string Email { get; }

        public UserEmailAlreadyExistException(string email) : base($"User with this email {email} already exist.")
        {
            Email = email;
        }
    }
}
