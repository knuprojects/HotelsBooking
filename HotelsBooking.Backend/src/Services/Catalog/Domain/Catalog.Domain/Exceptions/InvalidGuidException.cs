namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidGuidException : CustomException
    {
        public object GID { get; }
        public InvalidGuidException(object gid) : base($"Cannot set: {gid} as entity identifire.")
        {
            GID = gid;
        }
    }
}
