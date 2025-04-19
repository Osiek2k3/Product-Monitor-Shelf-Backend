using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Infrastructure.EF.Configurations
{
    public sealed class ProductShortageConfiguration : IEntityTypeConfiguration<ProductShortages>
    {
        public void Configure(EntityTypeBuilder<ProductShortages> builder)
        {
            //builder.ToTable("Department");

            builder.HasKey(ps => ps.ShortageId);

            builder.Property(ps => ps.ProductName)
                .IsRequired().HasMaxLength(255);

            builder.HasOne(ps => ps.Shelf)
                .WithMany(s => s.ProductShortages)
                .HasForeignKey(ps => ps.shopShelfId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}