using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Infrastructure.EF.Configurations
{
    public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //builder.ToTable("Department");

            builder.HasKey(x => x.DepartmentId);

            builder.Property(x => x.DepartmentId)
                .IsRequired().HasMaxLength(255);
        }
    }
}