using Identity.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Identity.Domain.ValueObjects
{
    public sealed class Email
    {
        private static readonly Regex regex = new(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled);

        public string Value { get; set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidEmailException(value);

            if (value.Length > 100)
                throw new InvalidEmailException(value);

            value = value.ToLowerInvariant();
            if (!regex.IsMatch(value))
            {
                throw new InvalidEmailException(value);
            }

            Value = value;
        }

        public static implicit operator Email(string value) => new(value);

        public static implicit operator string(Email email) => email.Value;
        public override string ToString() => Value;
    }
}
