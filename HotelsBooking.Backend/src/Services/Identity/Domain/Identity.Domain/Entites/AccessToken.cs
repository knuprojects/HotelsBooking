using System;

namespace Identity.Domain.Entites
{
    public sealed class AccessToken
    {
        public string Value { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
