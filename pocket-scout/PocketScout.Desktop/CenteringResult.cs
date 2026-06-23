using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketScout.Desktop
{
    public class CenteringResult
    {
        public int LeftBorderSize { get; set; }
        public int RightBorderSize { get; set; }
        public int TopBorderSize { get; set; }
        public int BottomBorderSize { get; set; }

        public double LeftPercent { get; set; }
        public double RightPercent { get; set; }
        public double TopPercent { get; set; }
        public double BottomPercent { get; set; }
    }
}
