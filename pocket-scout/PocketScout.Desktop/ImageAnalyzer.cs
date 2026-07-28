using System.Drawing;
/*
 * Pocket Scout: Card Grading
 * Brandon B
 * 07/27/2026
 */

namespace PocketScout.Desktop
{
    public class ImageAnalyzer
    {

        // Image Size
        public (int width, int height) GetImageSize(Bitmap image)
        {
            return (image.Width, image.Height);
        }

        // Card Outside Border
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

        public (int leftInnerBorder, int rightInnerBorder, int topInnerBorder, int bottomInnerBorder) GetCardInnerBorder(Bitmap image, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
        {
            int middleX = image.Width / 2;
            int middleY = image.Height / 2;

            int topInnerBorder = 0;
            int rightInnerBorder = 0;
            int leftInnerBorder = 0;
            int bottomInnerBorder = 0;

            int threshold = 128;

            // Get left inner border
            for (int x = leftBorder + 20; x < image.Width - rightBorder - 5; x++)
            {
                int previousAverage = GetAverageBrightnessHorizontal(image, x - 5, middleY, 5);
                int nextAverage = GetAverageBrightnessHorizontal(image, x, middleY, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    leftInnerBorder = x;
                    break;
                }
            }

            // Get right inner border
            for (int x = image.Width - rightBorder - 20; x > leftBorder + 5; x--)
            {
                int previousAverage = GetAverageBrightnessHorizontal(image, x, middleY, 5);
                int nextAverage = GetAverageBrightnessHorizontal(image, x - 5, middleY, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    rightInnerBorder = image.Width - x;
                    break;
                }
            }

            // Get top inner border
            for (int y = topBorder + 20; y < image.Height - bottomBorder - 5; y++)
            {
                int previousAverage = GetAverageBrightnessVertical(image, y - 5, middleX, 5);
                int nextAverage = GetAverageBrightnessVertical(image, y, middleX, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    topInnerBorder = y;
                    break;
                }
            }

            // Get bottom inner border
            for (int y = image.Height - bottomBorder - 20; y > topBorder + 5 ; y--)
            {
                int previousAverage = GetAverageBrightnessVertical(image, y - 5, middleX, 5);
                int nextAverage = GetAverageBrightnessVertical(image, y, middleX, 5);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    bottomInnerBorder = image.Height - y;
                    break;
                }
            }


            return (leftInnerBorder, rightInnerBorder, topInnerBorder, bottomInnerBorder);
        }

        // Avg Brightness Horizontal Helper Method
        private int GetAverageBrightnessHorizontal(Bitmap image, int startX, int fixedY, int amount)
        {
            int total = 0;

            for (int x = startX; x < startX + amount; x++){

                Color pixel = image.GetPixel(x, fixedY);
                total += (pixel.R + pixel.G + pixel.B) / 3;
            }

            return total / amount;
        }

        // Avg Brightness Veritcal Helper Method
        private int GetAverageBrightnessVertical(Bitmap image, int startY, int fixedX, int amount)
        {
            int total = 0;

            for(int y = startY; y < startY + amount; y++)
            {
                Color pixel = image.GetPixel(fixedX, y);
                total += (pixel.R + pixel.G + pixel.B) / 3;

            }
            return total / amount;
        }

        // Draw Debug Border Lines
        public Bitmap DrawBorderLines(Bitmap image, int leftBorder, int rightBorder, int topBorder, int bottomBorder, int leftInnerBorder, int rightInnerBorder, int topInnerBorder, int bottomInnerBorder)
        {
            Bitmap copy = new Bitmap(image);

            using (Graphics g = Graphics.FromImage(copy))
            using (Pen pen = new Pen(Color.Red, 3))
            {
                // Outer Borders
                int leftX = leftBorder;
                int rightX = image.Width - rightBorder;
                int topY = topBorder;
                int bottomY = image.Height - bottomBorder;

                // Inner Borders
                int leftInnerX = leftInnerBorder;
                int rightInnerX = image.Width - rightInnerBorder;
                int topInnerY = topInnerBorder;
                int bottomInnerY = image.Height - bottomInnerBorder;

                // Draw Outer Borders
                using (Pen outerPen = new Pen(Color.Red, 3)) 
                {
                    g.DrawLine(outerPen, leftX, 0, leftX, image.Height);
                    g.DrawLine(outerPen, rightX, 0, rightX, image.Height);
                    g.DrawLine(outerPen, 0, topY, image.Width, topY);
                    g.DrawLine(outerPen, 0, bottomY, image.Width, bottomY);
                }
                
                // Draw Inner Borders
                using (Pen innerPen = new Pen(Color.Blue, 3))
                {
                    g.DrawLine(innerPen, leftInnerX, 0, leftInnerX, image.Height);
                    g.DrawLine(innerPen, rightInnerX, 0, rightInnerX, image.Height);
                    g.DrawLine(innerPen, 0, topInnerY, image.Width, topInnerY);
                    g.DrawLine(innerPen, 0, bottomInnerY, image.Width, bottomInnerY);
                }
                

            }

            return copy;
        }
            
    }
}
