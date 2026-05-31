using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketScout.Core
{
    public class ImageAnalyzer
    {
        public (int left, int right) GetBorderWidths()
        {
            return (55, 45);
        }
    }
}
