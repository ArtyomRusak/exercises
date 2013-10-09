using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskApplication
{
    public class HelperClass
    {
        public HelperClass(int size, long time)
        {
            Time = time;
            Size = size;
        }

        public long Time { get; private set; }
        public int Size { get; private set; }
    }
}
