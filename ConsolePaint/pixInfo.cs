using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint
{
    internal class pixInfo
    {

        public int x_pixel { get; set; }
        public int y_pixel { get; set; }
        public int choose { get; set; }
        

        public pixInfo(int x_pixel, int y_pixel, int choose)
        {
            this.x_pixel = x_pixel;
            this.y_pixel = y_pixel;
            this.choose = choose;
        }

    }
}
