namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidNumberException : CustomException
    {
        public int Number { get; }
        public InvalidNumberException(int number) : base($"Number: '{number}' is invalid.")
        {
            Number = number;
        }
    }
}
