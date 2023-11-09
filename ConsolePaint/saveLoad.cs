using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint
{
    internal class saveLoad
    {

        private List<string> _files = new List<string>();
        public List<pixInfo> pixInfoLoad = new List<pixInfo>();

        public void Save(List<pixInfo> pixInfo)
        {
            for (int i = 0; i < pixInfo.Count; i++)
            {
                _files.Add(pixInfo[i].x_pixel.ToString() + "," + pixInfo[i].y_pixel.ToString() + "," + pixInfo[i].choose.ToString());
                File.WriteAllLines(@"ConsolePaint/ConsolePaint.wcp", _files);
            }
        }

        public void Load()
        {
            foreach (string line in File.ReadLines(@"ConsolePaint//ConsolePaint.wcp"))
            {
                string[] Load = line.Split(',');
                pixInfoLoad.Add(new pixInfo(int.Parse(Load[0]), int.Parse(Load[1]), int.Parse(Load[2])));
            }
        }

    }
}
