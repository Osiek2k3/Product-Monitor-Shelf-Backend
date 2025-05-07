
namespace ProductMonitorShelf.Core.Services
{
    public interface IImageProcessingService
    {
        public byte[] DrawRectangleOnImage(byte[] imageData, int xmin, int xmax, int ymin, int ymax);

    }
}
