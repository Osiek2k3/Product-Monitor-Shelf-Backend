using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Infrastructure.EF.Configurations;

namespace ProductMonitorShelf.Infrastructure.EF
{
    public sealed class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Shelf> Shelves { get; set; } = null!;
        public DbSet<ProductShortages> ProductShortages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductShortageConfiguration());
            modelBuilder.ApplyConfiguration(new ShelfConfiguration());
        }
    }
}