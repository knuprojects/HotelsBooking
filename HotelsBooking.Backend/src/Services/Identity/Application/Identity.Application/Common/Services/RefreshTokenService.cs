using Identity.Application.Common.Contracts;
using Identity.Dal.Data;
using Identity.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Application.Common.Services
{
    public class RefreshTokenService : IRefreshTokenRepository
    {
        private readonly IdentityDbContext _context;

        public RefreshTokenService(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task Create(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid gid)
        {
            RefreshToken refreshToken = await _context.RefreshTokens.FindAsync(gid);
            if (refreshToken != null)
            {
                _context.RefreshTokens.Remove(refreshToken);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAll(Guid userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
        }
    }
}
