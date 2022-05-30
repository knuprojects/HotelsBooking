using Identity.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Common.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetById(Guid userId);
        Task UpdateAsync(User user);
    }
}
