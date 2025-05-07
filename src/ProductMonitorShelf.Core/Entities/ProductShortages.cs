
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMonitorShelf.Core.Entities
{
    [Table("ProductShortages")]
    public class ProductShortages
    {
        public int ShortageId { get; set; } //id braku produktu
        public int shopShelfId { get; set; } //id regalu
        public string ProductName { get; set; } = null!; //nazwa produktu
        public int ProductNumber { get; set; } //numer produktu na półce od lewej strony
        public int ShelfNumber { get; set; } // numer półki od góry danego regału
        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }
        public byte[] FileData { get; set; }  //sciezka do pliku

        public Shelf Shelf { get; set; } = null!;
    }
}