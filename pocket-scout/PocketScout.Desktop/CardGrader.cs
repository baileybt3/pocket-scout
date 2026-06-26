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
            int outerTopY = outerBorder.topBorder;
            int outerBottomY = image.Height - outerBorder.bottomBorder;

            // Inner border coordinates
            int innerLeftX = innerBorder.leftInnerBorder;
            int innerRightX = image.Width - innerBorder.rightInnerBorder;
            int innerTopY = innerBorder.topInnerBorder;
            int innerBottomY = image.Height - innerBorder.bottomInnerBorder;

            // Calculate card border thickness
            int leftBorderSize = innerLeftX - outerLeftX;
            int rightBorderSize = outerRightX - innerRightX;
            int topBorderSize = innerTopY - outerTopY;
            int bottomBorderSize = outerBottomY - innerBottomY;

            int horizontalTotal = leftBorderSize + rightBorderSize;
            int verticalTotal = topBorderSize + bottomBorderSize;

            CenteringResult result = new CenteringResult();

            result.LeftBorderSize = leftBorderSize;
            result.RightBorderSize = rightBorderSize;
            result.TopBorderSize = topBorderSize;
            result.BottomBorderSize = bottomBorderSize;

            if(horizontalTotal > 0)
            {
                result.LeftPercent = (double)leftBorderSize / horizontalTotal * 100;
                result.RightPercent = (double)rightBorderSize / horizontalTotal * 100;
            }

            if(verticalTotal > 0)
            {
                result.TopPercent = (double)topBorderSize / verticalTotal * 100;
                result.BottomPercent = (double)bottomBorderSize / verticalTotal * 100;
            }

            return result;
        }
    }
}
