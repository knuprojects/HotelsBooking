using System;

namespace Identity.Application.Exceptions
{
    public class UserNotFoundException : CustomException
    {
        public Guid Gid { get; }

        public UserNotFoundException(Guid gid) : base($"User not found.")
        {
            Gid = gid;
        }
    }
}
