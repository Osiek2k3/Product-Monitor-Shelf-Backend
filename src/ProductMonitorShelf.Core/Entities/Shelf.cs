
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMonitorShelf.Core.Entities
{
    [Table("Shelf")]
    public class Shelf
    {
        public int shopShelfId { get; set; }
        public int DepartmentId { get; set; }
        public int ShelfUnit { get; set; }

        public Department Department { get; set; } = null!;

        public ICollection<ProductShortages> ProductShortages { get; set; } = new List<ProductShortages>();
    }
}