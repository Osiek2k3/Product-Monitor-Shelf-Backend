using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Exceptions;
using ProductMonitorShelf.Core.Services;
using ProductMonitorShelf.Infrastructure.EF;
using ProductMonitorShelf.Infrastructure.Services;
using System.Drawing.Printing;

namespace ProductMonitorShelf.Infrastructure.Repositories
{
    internal sealed class ProductShortageRepository : IProductShortageRepository
    {
        private readonly MyDbContext _dbContext;
        private readonly IImageProcessingService _imageProcessingService;

        public ProductShortageRepository(MyDbContext dbContext,
            IImageProcessingService imageProcessingService)
        {
            _dbContext = dbContext;
            _imageProcessingService = imageProcessingService;
        }

        public async Task<ProductShortages> GetByIdAsync(int productShortageId)
        {
            try
            {
                var result = await _dbContext.ProductShortages
                                .Include(ps => ps.Shelf)
                                .FirstOrDefaultAsync(ps => ps.ShortageId == productShortageId);
                if (result == null)
                {
                    throw new NotFoundException("Nie ma takiego braku o tym ID");
                }

                var updatedImage = _imageProcessingService.DrawRectangleOnImage(
                    result.FileData,
                    (int)result.Xmin,
                    (int)result.Xmax,
                    (int)result.Ymin,
                    (int)result.Ymax
                );

                result.FileData = updatedImage;

                _dbContext.ProductShortages.Update(result);
                await _dbContext.SaveChangesAsync();

                return result;
            }
            catch (NotFoundException ex)
            { 
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
            }
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
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
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
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
            }
        }

        public async Task<IEnumerable<ProductShortages>> GetAllProductInCategoryAsync(int categoryId)
        {
            try
            {
                var result = await _dbContext.ProductShortages
                            .Include(ps => ps.Shelf)
                            .Where(ps => ps.Shelf.DepartmentId == categoryId)
                            .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
            }
        }
        public async Task<IEnumerable<ProductShortages>> GetProductsInCategorieWithPaginationAsync(
            int categoryId, int pageNumber, int pageSize)
        {
            try
            {
                var result = await _dbContext.ProductShortages
                                .Include(p => p.Shelf)
                                .Where(ps => ps.Shelf.DepartmentId == categoryId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
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
                throw new DatabaseException("Błąd podczas pobierania braków kategori.", ex);
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
                    throw new NotFoundException($"Nie znaleziono braku produktu o ID {productShortageId}.");
                }

                _dbContext.ProductShortages.Remove(shortage);
                await _dbContext.SaveChangesAsync();
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Błąd podczas usuwania braku produktu o ID {productShortageId}.", ex);
            }
        }
    }
}