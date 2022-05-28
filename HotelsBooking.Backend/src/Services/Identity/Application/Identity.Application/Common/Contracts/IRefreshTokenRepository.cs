using Identity.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Common.Contracts
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string token);

        Task Create(RefreshToken refreshToken);

        Task Delete(Guid id);

        Task DeleteAll(Guid userId);
    }
}
