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
            // Get to middle row of image (temporary)

            int y = image.Height / 2;

            int leftBorder = 0;
            int rightBorder = 0;

            int threshold = 40; // Adjust threshold base on card's background color

            for (int x = 5; x < image.Width - 5; x++)
            {
                int previousAverage = GetAverageBrightness(image, x - 5, y, 5);
                int nextAverage = GetAverageBrightness(image, x, y, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    leftBorder = x;
                    break;
                }
            }

            for (int x = image.Width - 6; x > 5; x--) {
                int previousAverage = GetAverageBrightness(image, x, y, 5);
                int nextAverage = GetAverageBrightness(image, x - 5, y, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    rightBorder = image.Width - x;
                    break;
                }
            }

            return (leftBorder, rightBorder);
        }

        // Avg Brightness Helper Method
        private int GetAverageBrightness(Bitmap image, int startX, int y , int amount)
        {
            int total = 0;

            for (int x = startX; x < startX + amount; x++){

                Color pixel = image.GetPixel(x, y);

                int brightness = (pixel.R + pixel.G + pixel.B) / 3;

                total += brightness;
            }

            return total / amount;
        }

        // Draw Debug Border Lines
        public Bitmap DrawBorderLines(Bitmap image, int leftBorder, int rightBorder)
        {
            Bitmap copy = new Bitmap(image);

            using (Graphics g = Graphics.FromImage(copy))
            using (Pen pen = new Pen(Color.Red, 3))
            {
                int leftX = leftBorder;
                int rightX = image.Width - rightBorder;

                g.DrawLine(pen, leftX, 0, leftX, image.Height);
                g.DrawLine(pen, rightX, 0, rightX, image.Height);
            }

            return copy;
        }
            
    }
}
