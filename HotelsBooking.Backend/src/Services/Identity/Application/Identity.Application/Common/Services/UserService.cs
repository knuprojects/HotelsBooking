using Identity.Application.Common.Contracts;
using Identity.Application.Exceptions;
using Identity.Dal.Common.Contracts;
using Identity.Dal.Data;
using Identity.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Application.Common.Services
{
    public class UserService : IUserRepository
    {
        private readonly IdentityDbContext _context;
        private readonly IEfRepository<User> _efRepository;

        public UserService(IdentityDbContext context,
            IEfRepository<User> efRepository)
        {
            _context = context;
            _efRepository = efRepository;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (result == null)
                throw new UserEmailNotFoundException(email);

            return result;
        }

        public User GetById(Guid gid)
        {
            var result = _context.Users.FirstOrDefault(x => x.GID == gid);

            if (result == null)
                throw new UserNotFoundException(gid);

            return result;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

            if (result == null)
                throw new UserLoginNotFoundException(login);

            return result;
        }

        public Task UpdateAsync(User user)
        {
            _efRepository.Update(user);

            return Task.CompletedTask;
        }
    }
}
