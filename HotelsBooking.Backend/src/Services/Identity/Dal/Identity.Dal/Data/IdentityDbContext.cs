using Identity.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Identity.Dal.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
