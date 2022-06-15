using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.DAL.Configurations
{
    internal sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new Id(x));
            builder.Property(x => x.Number)
                .HasConversion(x => x.Value, x => new Number(x))
                .IsRequired();
            builder.Property(x => x.Floor)
                .HasConversion(x => x.Value, x => new Floor(x))
                .IsRequired();
            builder.Property(x => x.RoomType)
                .IsRequired();
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x))
                .IsRequired();
            builder.Property(x => x.HotelId)
                .IsRequired();
        }
    }
}
