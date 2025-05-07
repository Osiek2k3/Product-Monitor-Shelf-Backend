using ProductMonitorShelf.Core.Services;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProductMonitorShelf.Infrastructure.Services
{
    public class ImageProcessingService : IImageProcessingService
    {
        public byte[] DrawRectangleOnImage(byte[] imageData, int xmin, int xmax, int ymin, int ymax)
        {
            using (var inputStream = new MemoryStream(imageData))
            using (var image = new Bitmap(inputStream))
            using (var graphics = Graphics.FromImage(image))
            using (var pen = new Pen(Color.Red, 6))
            {
                int width = xmax - xmin;
                int height = ymax - ymin;

                graphics.DrawRectangle(pen, xmin, ymin, width, height);

                using (var outputStream = new MemoryStream())
                {
                    image.Save(outputStream, ImageFormat.Jpeg);
                    return outputStream.ToArray();
                }
            }
        }
    }
}
