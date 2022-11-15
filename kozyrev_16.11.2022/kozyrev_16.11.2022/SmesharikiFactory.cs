using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozyrev_16._11._2022
{
    static class SmesharikiFactory
    {
        public static void Process<T>(T smeshariki) where T : Smeshariki
        {
            smeshariki.Voice();
        }
    }
}
