namespace Identity.Application.Exceptions
{
    public class UserEmailNotFoundException : CustomException
    {
        public string Email { get; }

        public UserEmailNotFoundException(string email) : base($"User with this email {email} not exist.")
        {
            Email = email;
        }
    }
}
