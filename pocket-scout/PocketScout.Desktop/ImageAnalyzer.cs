using System.Drawing;

namespace PocketScout.Desktop
{
    public class ImageAnalyzer
    {
        public (int width, int height) GetImageSize(Bitmap image)
        {
            return (image.Width, image.Height);
        }

        public (int leftBorder, int rightBorder) GetCardBorder(Bitmap image)
        {

            int leftBorder = 25;
            int rightBorder = 30;

            return (leftBorder, rightBorder);
        }
            
    }
}
