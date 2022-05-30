using Identity.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Domain.ValueObjects
{
    public sealed class Role
    {
        public IEnumerable<string> AvailableRoles { get; } = new[] { "admin", "user" };

        public string Value { get; set; }

        public Role(string value)
        {
            if (!AvailableRoles.Contains(value))
                throw new InvalidRoleException(value);

            Value = value;
        }

        public static Role Admin => new Role("admin");
        public static Role User => new Role("user");
        public static implicit operator Role(string value) => new Role(value);
        public static implicit operator string(Role value) => value.Value;
        public override string ToString() => Value;
    }
}
