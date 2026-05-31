using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketScout.Core
{
    public class CardGrader
    {
        public CenteringResult AnalyzeCentering(int leftBorderWidth, int rightBorderWidth)
        {
            int total = leftBorderWidth + rightBorderWidth;

            if(total <= 0)
            {
                return new CenteringResult
                {
                    LeftPercent = 0,
                    RightPercent = 0
                };
            }

            int leftPercent = (int)Math.Round((double)leftBorderWidth / total * 100);
            int rightPercent = 100 - leftPercent;

            return new CenteringResult
            {
                LeftPercent = leftPercent,
                RightPercent = rightPercent
            };
        }
    }

    public class CenteringResult
    {
        public int LeftPercent { get; set; }
        public int RightPercent { get; set; }

        public override string ToString()
        {
            return $"{LeftPercent}/{RightPercent}";
        }
    }
}
