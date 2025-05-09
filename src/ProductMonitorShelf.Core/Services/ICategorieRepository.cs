using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Services
{
    public interface ICategorieRepository
    {
        Task<IEnumerable<Categorie>> GetAllAsync();
    }
}
