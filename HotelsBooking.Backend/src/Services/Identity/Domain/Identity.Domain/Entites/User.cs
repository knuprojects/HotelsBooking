using Identity.Domain.ValueObjects;
using System;

namespace Identity.Domain.Entites
{
    public class User : BaseEntity
    {
        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }
        public DateTime DatedJoined { get; private set; } = DateTime.UtcNow;

        public User(Login login, Email email, Password password, Role role)
        {
            Login = login;  
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
