using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.DAL.Configurations
{
    internal sealed class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(x => x.GID);
            builder.Property(x => x.GID)
                .HasConversion(x => x.Value, x => new GID(x));
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(x => x.Description)
                .HasConversion(x => x.Value, x => new Description(x))
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.City)
                .HasConversion(x => x.Value, x => new City(x))
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(x => x.PhotoUrl).IsUnique();
            builder.Property(x => x.PhotoUrl)
                .HasConversion(x => x.Value, x => new PhotoUrl(x))
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
