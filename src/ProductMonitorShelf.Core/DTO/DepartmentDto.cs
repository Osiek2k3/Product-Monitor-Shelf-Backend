using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.DTO
{
    public sealed class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public static DepartmentDto ToMap(Department x)
        {
            return new DepartmentDto
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            };
        }
    }
}
