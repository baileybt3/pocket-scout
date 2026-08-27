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

        // Image Brightness Map
        public int[,] GetBrightnessMap(Bitmap image)
        {
            int[,] brightnessMap = new int[image.Width, image.Height];
            for (int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int brightness = (pixel.R + pixel.G + pixel.B) / 3;
                    brightnessMap[x, y] = brightness;
                }
            }

            return (brightnessMap);
        }

        // Card Outside Border
        public (int leftBorder, int rightBorder, int topBorder, int bottomBorder) GetCardBorder(int[,] brightnessMap)
        {
            // Get to middle row of image (temporary)

            int width = brightnessMap.GetLength(0);
            int height = brightnessMap.GetLength(1);

            int middleX = width / 2;
            int middleY = height / 2;

            int leftBorder = 0;
            int rightBorder = 0;
            int topBorder = 0;
            int bottomBorder = 0;

            int threshold = 140; // Adjust threshold base on card's background color
            int windowSize = 5; // Number of pixels to average for brightness comparison

            // Find left border
            for (int x = windowSize; x < width - windowSize; x++)
            {
                int previousAverage = GetAverageBrightnessHorizontal(brightnessMap, x - windowSize, middleY, windowSize);
                int nextAverage = GetAverageBrightnessHorizontal(brightnessMap, x, middleY, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    leftBorder = x;
                    break;
                }
            }

            // Get right border
            for (int x = width - windowSize; x > windowSize; x--) {
                int previousAverage = GetAverageBrightnessHorizontal(brightnessMap, x, middleY, windowSize);
                int nextAverage = GetAverageBrightnessHorizontal(brightnessMap, x - windowSize, middleY, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    rightBorder = width - x;
                    break;
                }
            }

            // Get top border
            for (int y = windowSize; y < height - windowSize; y++)
            {
                int previousAverage = GetAverageBrightnessVertical(brightnessMap, y - windowSize, middleX, windowSize);
                int nextAverage = GetAverageBrightnessVertical(brightnessMap, y, middleX, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if(difference > threshold)
                {
                    topBorder = y;
                    break;
                }
            }
            

            // Get bottom border
            for (int y = height - windowSize; y > windowSize; y--)
            {
                int previousAverage = GetAverageBrightnessVertical(brightnessMap, y - windowSize, middleX, windowSize);
                int nextAverage = GetAverageBrightnessVertical(brightnessMap, y, middleX, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    bottomBorder = height - y;
                    break;
                }
            }

            return (leftBorder, rightBorder, topBorder, bottomBorder);
        }

        // Get Card Inner Border
        public (int leftInnerBorder, int rightInnerBorder, int topInnerBorder, int bottomInnerBorder) GetCardInnerBorder(int[,] brightnessMap, int leftBorder, int rightBorder, int topBorder, int bottomBorder)
        {
            int width = brightnessMap.GetLength(0);
            int height = brightnessMap.GetLength(1);

            int middleX = width / 2;
            int middleY = height / 2;

            int topInnerBorder = 0;
            int rightInnerBorder = 0;
            int leftInnerBorder = 0;
            int bottomInnerBorder = 0;

            int threshold = 40;
            int windowSize = 5;

            // Get left inner border
            for (int x = leftBorder + windowSize; x < width - rightBorder - windowSize; x++)
            {
                int previousAverage = GetAverageBrightnessHorizontal(brightnessMap, x - windowSize, middleY, windowSize);
                int nextAverage = GetAverageBrightnessHorizontal(brightnessMap, x, middleY, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    leftInnerBorder = x;
                    break;
                }
            }

            // Get right inner border
            for (int x = width - rightBorder - 20; x > leftBorder + windowSize; x--)
            {
                int previousAverage = GetAverageBrightnessHorizontal(brightnessMap, x, middleY, windowSize);
                int nextAverage = GetAverageBrightnessHorizontal(brightnessMap, x - windowSize, middleY, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    rightInnerBorder = width - x;
                    break;
                }
            }

            // Get top inner border
            for (int y = topBorder + windowSize; y < height - bottomBorder - windowSize; y++)
            {
                int previousAverage = GetAverageBrightnessVertical(brightnessMap, y - windowSize, middleX, windowSize);
                int nextAverage = GetAverageBrightnessVertical(brightnessMap, y, middleX, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    topInnerBorder = y;
                    break;
                }
            }

            // Get bottom inner border
            for (int y = height - bottomBorder - 20; y > topBorder + windowSize ; y--)
            {
                int previousAverage = GetAverageBrightnessVertical(brightnessMap, y - windowSize, middleX, windowSize);
                int nextAverage = GetAverageBrightnessVertical(brightnessMap, y, middleX, windowSize);

                int difference = Math.Abs(previousAverage - nextAverage);

                if (difference > threshold)
                {
                    bottomInnerBorder = height - y;
                    break;
                }
            }


            return (leftInnerBorder, rightInnerBorder, topInnerBorder, bottomInnerBorder);
        }

        // Avg Brightness Horizontal Helper Method
        private int GetAverageBrightnessHorizontal(int[,] brightnessMap, int startX, int fixedY, int amount)
        {
            int total = 0;

            for (int x = startX; x < startX + amount; x++){

                total += brightnessMap[x, fixedY];
            }

            return total / amount;
        }

        // Avg Brightness Veritcal Helper Method
        private int GetAverageBrightnessVertical(int[,] brightnessMap, int startY, int fixedX, int amount)
        {
            int total = 0;

            for(int y = startY; y < startY + amount; y++)
            {
                total += brightnessMap[fixedX, y];

            }
            return total / amount;
        }


        // Draw Debug Border Lines
        public Bitmap DrawBorderLines(Bitmap image, int leftBorder, int rightBorder, int topBorder, int bottomBorder, int leftInnerBorder, int rightInnerBorder, int topInnerBorder, int bottomInnerBorder)
        {
            Bitmap copy = new Bitmap(image);

            using (Graphics g = Graphics.FromImage(copy))
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
