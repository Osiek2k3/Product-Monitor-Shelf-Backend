using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Services
{
    public interface IProductShortageRepository
    {
        Task<ProductShortages> GetByIdAsync(int productShortageId);
        Task<IEnumerable<ProductShortages>> GetAllAsync();
        Task<IEnumerable<ProductShortages>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> GetDepartamentCountAsync(int departmentId);
        Task DeleteAsync(int productShortageId);
    }
}