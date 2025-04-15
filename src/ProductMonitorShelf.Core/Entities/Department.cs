
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMonitorShelf.Core.Entities
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}
