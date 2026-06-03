using System.Drawing;

namespace PocketScout.Desktop
{
    public class ImageAnalyzer
    {
        public (int width, int height) GetImageSize(Bitmap image)
        {
            return (image.Width, image.Height);
        }
    }
}
