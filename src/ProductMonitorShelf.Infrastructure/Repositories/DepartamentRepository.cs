using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Services;
using ProductMonitorShelf.Infrastructure.EF;

namespace ProductMonitorShelf.Infrastructure.Repositories
{
    public class DepartamentRepository : IDepartmentRepository
    {
        private readonly MyDbContext _dbContext;
        public DepartamentRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.Departments
                                .Include(p => p.Shelves)
                                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Błąd podczas pobierania braków kategori.", ex);
            }
        }
    }
}
