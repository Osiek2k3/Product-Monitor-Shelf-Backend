using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Services
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
    }
}
