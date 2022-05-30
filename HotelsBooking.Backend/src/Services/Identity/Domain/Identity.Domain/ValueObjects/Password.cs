using Identity.Domain.Exceptions;

namespace Identity.Domain.ValueObjects
{
    public sealed class Password
    {
        public string Value { get; set; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length is > 36 or < 8)
                throw new InvalidPasswordException(value);

            Value = value;
        }

        public static implicit operator Password(string value) => new(value);
        public static implicit operator string(Password value) => value.Value;
        public override string ToString() => Value;
    }
}
