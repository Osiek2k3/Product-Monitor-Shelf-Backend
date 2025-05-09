using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Infrastructure.EF.Configurations
{
    public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            //builder.ToTable("Department");

            builder.HasKey(x => x.DepartmentId);

            builder.Property(x => x.DepartmentId)
                .IsRequired().HasMaxLength(255);
        }
    }
}