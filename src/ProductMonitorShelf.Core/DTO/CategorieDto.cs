using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.DTO
{
    public sealed class CategorieDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public static CategorieDto ToMap(Categorie x)
        {
            return new CategorieDto
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            };
        }
    }
}
