using Identity.Domain.Entites;
using Identity.Domain.Models.Request;
using Identity.Domain.Models.Response;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Common.Contracts
{
    internal interface IIdentityRepository
    {
        Task<LoginResponse> Authenticate(User user);
        Task Register(RegistrationRequest request);
        Task ChangePasswordAsync(Guid userGid, string currentPassword, string newPassword);
    }
}
