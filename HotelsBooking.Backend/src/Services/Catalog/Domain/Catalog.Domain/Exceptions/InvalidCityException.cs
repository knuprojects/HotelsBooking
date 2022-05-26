namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidCityException : CustomException
    {
        public string City { get; }
        public InvalidCityException(string city) : base($"City: '{city}' is invalid.")
        {
            City = city;
        }
    }
}
