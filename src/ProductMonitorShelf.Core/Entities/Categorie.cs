
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMonitorShelf.Core.Entities
{
    [Table("Department")]
    public class Categorie
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}