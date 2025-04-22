using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Services;
using ProductMonitorShelf.Infrastructure.EF;

namespace ProductMonitorShelf.Infrastructure.Repositories
{
    internal sealed class ProductShortageRepository : IProductShortageRepository
    {
        private readonly MyDbContext _dbContext;

        public ProductShortageRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductShortages>> GetAllAsync()
        {
            try
            {
                var result = await _dbContext.ProductShortages
                                .Include(p => p.Shelf)
                                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Błąd podczas pobierania braków produktów.", ex);
            }
        }

        public async Task<IEnumerable<ProductShortages>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            try
            {
                var result = await _dbContext.ProductShortages
                                .Include(p => p.Shelf)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Błąd podczas pobierania braków produktów.", ex);
            }
        }

        public async Task<int> GetDepartamentCountAsync(int departmentId)
        {
            try
            {
                var result = await _dbContext.ProductShortages
                                .CountAsync(ps => ps.Shelf.DepartmentId == departmentId);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Błąd podczas pobierania braków kategori.", ex);
            }
        }
        public async Task DeleteAsync(int productShortageId)
        {
            try
            {
                var shortage = await _dbContext.ProductShortages
                    .FirstOrDefaultAsync(ps => ps.ShortageId == productShortageId);

                if (shortage == null)
                {
                    throw new KeyNotFoundException($"Nie znaleziono braku produktu o ID {productShortageId}.");
                }

                _dbContext.ProductShortages.Remove(shortage);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Błąd podczas usuwania braku produktu o ID {productShortageId}.", ex);
            }
        }
    }
}