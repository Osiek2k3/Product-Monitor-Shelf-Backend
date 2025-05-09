using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.UseCase;

namespace ProductMonitorShelf.Core.Services
{
    public interface IProductShortageRepository
    {
        Task<ProductShortages> GetByIdAsync(int productShortageId);
        Task<IEnumerable<ProductShortages>> GetAllAsync();
        Task<IEnumerable<ProductShortages>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<IEnumerable<ProductShortages>> GetProductsInCategorieWithPaginationAsync(int categoryId, int pageNumber, int pageSize);
        Task<IEnumerable<ProductShortages>> GetAllProductInCategoryAsync(int categoryId);
        Task<int> GetDepartamentCountAsync(int departmentId);
        Task DeleteAsync(int productShortageId);
    }
}