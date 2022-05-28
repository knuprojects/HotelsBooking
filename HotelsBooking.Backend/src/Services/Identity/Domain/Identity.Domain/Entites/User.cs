using Identity.Domain.ValueObjects;
using System;

namespace Identity.Domain.Entites
{
    public class User : BaseEntity
    {
        public Login Login { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Role[] Role { get; set; }
        public DateTime DatedJoined { get; private set; } = DateTime.UtcNow;
    }
}
