namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidNameException : CustomException
    {
        public string Name { get; }
        public InvalidNameException(string name) : base($"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
