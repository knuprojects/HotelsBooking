using Catalog.Domain.Exceptions;

namespace Catalog.Domain.ValueObjects
{
    public sealed class PhotoUrl
    {
        public string Value { get; }
        public PhotoUrl(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length is > 256 or < 12)
                throw new InvalidPhotoUrlException(value);

            Value = value;
        }

        public static implicit operator PhotoUrl(string value) => value is null ? null : new PhotoUrl(value);

        public static implicit operator string(PhotoUrl value) => value.Value;
        public override string ToString() => Value;
    }
}
