
namespace ProductMonitorShelf.Core.Entities
{
    public class ProductShortagesArchive
    {
        public int ShortageId { get; set; }
        public int shopShelfId { get; set; }
        public string? ProductName { get; set; }
        public int ProductNumber { get; set; }
        public int ShelfNumber { get; set; }
        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }
        public byte[] FileData { get; set; }
        public DateTime ArchivedDate { get; set; } = DateTime.UtcNow;
    }
}
