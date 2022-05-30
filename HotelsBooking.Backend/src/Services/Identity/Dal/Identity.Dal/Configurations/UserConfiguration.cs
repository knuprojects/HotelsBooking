using Identity.Domain.Entites;
using Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Dal.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.GID);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x))
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Login).IsUnique();
            builder.Property(x => x.Login)
                .HasConversion(x => x.Value, x => new Login(x))
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(x => x.Password)
                .HasConversion(x => x.Value, x => new Password(x))
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(x => x.Role)
                .HasConversion(x => x.Value, x => new Role(x))
                .IsRequired();
        }
    }
}
