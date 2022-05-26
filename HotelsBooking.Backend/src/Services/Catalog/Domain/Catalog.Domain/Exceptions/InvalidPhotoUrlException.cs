namespace Catalog.Domain.Exceptions
{
    public sealed class InvalidPhotoUrlException : CustomException
    {
        public string PhotoUrl { get; }
        public InvalidPhotoUrlException(string photoUrl) : base($"PhotoUrl: '{photoUrl}' is invalid.")
        {
            PhotoUrl = photoUrl;
        }
    }
}
