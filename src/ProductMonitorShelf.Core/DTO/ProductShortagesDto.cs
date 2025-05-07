
using ProductMonitorShelf.Core.Entities;

namespace ProductMonitorShelf.Core.DTO
{
    public sealed class ProductShortagesDto
    {
        public string ShortageId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ShelfUnit { get; set; }
        public string? ShelfNumber { get; set; }
        public string? ProductNumber { get; set; }
        public byte[]? FileData{ get; set; }
        public string? DepartmentId { get; set; }

        public static ProductShortagesDto ToMap(ProductShortages x)
        {
            return new ProductShortagesDto
            {
                ShortageId = x.ShortageId.ToString(),
                ProductName = x.ProductName,
                ShelfUnit = x.Shelf.ShelfUnit.ToString(),
                ShelfNumber = x.ShelfNumber.ToString(),
                ProductNumber = x.ProductNumber.ToString(),
                FileData = x.FileData,
                DepartmentId = x.Shelf.DepartmentId.ToString(),
            };
        }
    }
}