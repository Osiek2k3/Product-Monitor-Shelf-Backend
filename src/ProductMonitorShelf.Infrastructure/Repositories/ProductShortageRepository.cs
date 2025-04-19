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
                                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Błąd podczas pobierania braków produktów.", ex);
            }
        }
    }
}

