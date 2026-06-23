using PocketScout.Desktop;
using System.Drawing;

namespace PocketScout.Desktop
{
    public class CardGrader
    {
        public CenteringResult CalculateCentering(Bitmap image,
            (int leftBorder, int rightBorder, int topBorder, int bottomBorder) outerBorder,
            (int leftInnerBorder, int rightInnerBorder, int topInnerBorder, int bottomInnerBorder) innerBorder)
        {
            // Convert outer border values into actual image coordinates
            int outerLeftX = outerBorder.leftBorder;
            int outerRightX = image.Width - outerBorder.rightBorder;

            // Inner border coordinates
            int innerLeftX = innerBorder.leftInnerBorder;
            int innerRightX = image.Width - innerBorder.rightInnerBorder;

            // Calculate card border thickness
            int leftBorderSize = innerLeftX - outerLeftX;
            int rightBorderSize = outerRightX - innerRightX;

            int horizontalTotal = leftBorderSize + rightBorderSize;

            CenteringResult result = new CenteringResult();

            result.LeftBorderSize = leftBorderSize;
            result.RightBorderSize = rightBorderSize;

            if(horizontalTotal > 0)
            {
                result.LeftPercent = (double)leftBorderSize / horizontalTotal * 100;
                result.RightPercent = (double)rightBorderSize / horizontalTotal * 100;
            }

            return result;
        }
    }
}
