using Identity.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Identity.Application.Common.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByEmailAsync(string email);
        User GetById(Guid gid);
        Task UpdateAsync(User user);
    }
}
