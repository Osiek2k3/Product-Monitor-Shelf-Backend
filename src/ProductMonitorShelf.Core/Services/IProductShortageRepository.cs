using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Services
{
    public interface IProductShortageRepository
    {
        Task<IEnumerable<ProductShortages>> GetAllAsync();
    }
}
