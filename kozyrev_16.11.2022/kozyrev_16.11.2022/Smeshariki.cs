using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozyrev_16._11._2022
{
    abstract class Smeshariki
    {
        public abstract string Name { get; set; }
        public abstract string Color { get; set; }

        public abstract void Voice();
    }
}
