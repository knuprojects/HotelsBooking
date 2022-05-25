using Identity.Domain.Exceptions;

namespace Identity.Domain.ValueObjects
{
    public sealed class Login
    {
        public string Value { get; }

        public Login(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 36 or < 3)
                throw new InvalidLoginException(value);

            Value = value;
        }

        public static implicit operator Login(string value) => value is null ? null : new Login(value);

        public static implicit operator string(Login login) => login.Value;
        public override string ToString() => Value;
        
    }
}
