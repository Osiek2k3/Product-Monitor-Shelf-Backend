using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Infrastructure.EF.Configurations
{
    public sealed class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            //builder.ToTable("Shelf");

            builder.HasKey(s => s.shopShelfId);

            builder.HasOne(s => s.Department)
                  .WithMany(d => d.Shelves)
                  .HasForeignKey(s => s.DepartmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}