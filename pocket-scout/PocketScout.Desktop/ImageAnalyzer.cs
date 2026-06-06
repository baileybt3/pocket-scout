using System.Drawing;

namespace PocketScout.Desktop
{
    public class ImageAnalyzer
    {
        public (int width, int height) GetImageSize(Bitmap image)
        {
            return (image.Width, image.Height);
        }

        public (int leftBorder, int rightBorder, int topBorder, int bottomBorder) GetCardBorder(Bitmap image)
        {
            // Get to middle row of image (temporary)

            int middleY = image.Height / 2;
            int middleX = image.Width / 2;

            int leftBorder = 0;
            int rightBorder = 0;
            int topBorder = 0;
            int bottomBorder = 0;

            int threshold = 120; // Adjust threshold base on card's background color

            // Get left border
            for (int x = 5; x < image.Width - 5; x++)
            {
                int previousAverage = GetAverageBrightnessHorizontal(image, x - 5, middleY, 5);
                int nextAverage = GetAverageBrightnessHorizontal(image, x, middleY, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    leftBorder = x;
                    break;
                }
            }

            // Get right border
            for (int x = image.Width - 6; x > 5; x--) {
                int previousAverage = GetAverageBrightnessHorizontal(image, x, middleY, 5);
                int nextAverage = GetAverageBrightnessHorizontal(image, x - 5, middleY, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    rightBorder = image.Width - x;
                    break;
                }
            }

            // Get top border
            for (int y = 5; y < image.Height - 5; y++)
            {
                int previousAverage = GetAverageBrightnessVertical(image, y - 5, middleX, 5);
                int nextAverage = GetAverageBrightnessVertical(image, y, middleX, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    topBorder = y;
                    break;
                }
            }
            

            // Get bottom border
            for (int y = image.Height - 6; y > 5; y--)
            {
                int previousAverage = GetAverageBrightnessVertical(image, y - 5, middleX, 5);
                int nextAverage = GetAverageBrightnessVertical(image, y, middleX, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    bottomBorder = image.Height - y;
                    break;
                }
            }

            return (leftBorder, rightBorder, topBorder, bottomBorder);
        }

        // Avg Brightness Horizontal Helper Method
        private int GetAverageBrightnessHorizontal(Bitmap image, int startX, int y, int amount)
        {
            int total = 0;

            for (int x = startX; x < startX + amount; x++){

                Color pixel = image.GetPixel(x, y);
                total += (pixel.R + pixel.G + pixel.B) / 3;
            }

            return total / amount;
        }

        // Avg Brightness Veritcal Helper Method
        private int GetAverageBrightnessVertical(Bitmap image, int startY, int x, int amount)
        {
            int total = 0;

            for(int y = startY; y < startY + amount; y++)
            {
                Color pixel = image.GetPixel(x, y);
                total += (pixel.R + pixel.G + pixel.B) / 3;

            }
            return total / amount;
        }

        // Draw Debug Border Lines
        public Bitmap DrawBorderLines(Bitmap image, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
        {
            Bitmap copy = new Bitmap(image);

            using (Graphics g = Graphics.FromImage(copy))
            using (Pen pen = new Pen(Color.Red, 3))
            {
                int leftX = leftBorder;
                int rightX = image.Width - rightBorder;
                int topY = topBorder;
                int bottomY = image.Height - bottomBorder;

                g.DrawLine(pen, leftX, 0, leftX, image.Height);
                g.DrawLine(pen, rightX, 0, rightX, image.Height);
                g.DrawLine(pen, 0, topY, image.Width, topY);
                g.DrawLine(pen, 0, bottomY, image.Width, bottomY);

            }

            return copy;
        }
            
    }
}
