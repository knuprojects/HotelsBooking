using System;

namespace Identity.Domain.Entites
{
    public sealed class RefreshToken
    {
        public Guid GID { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
