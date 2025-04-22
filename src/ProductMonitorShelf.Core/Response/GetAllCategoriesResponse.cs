using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.Response
{
    public class GetAllCategoriesResponse
    {
        public DepartmentDto Department { get; set; }
        public int Count { get; set; }

        public GetAllCategoriesResponse(Department department ,int count)
        {
            Department = DepartmentDto.ToMap(department);
            Count = count;
        }
    }
}
