namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidIdException : CustomException
    {
        public object Id { get; }
        public InvalidIdException(object id) : base($"Cannot set: {id} as entity identifire.")
        {
            Id = id;
        }
    }
}
