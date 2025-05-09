using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Response
{
    public class GetAllCategoriesResponse
    {
        public CategorieDto Department { get; set; }
        public int Count { get; set; }

        public GetAllCategoriesResponse(Categorie department ,int count)
        {
            Department = CategorieDto.ToMap(department);
            Count = count;
        }
    }
}
