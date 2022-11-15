using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozyrev_16._11._2022
{
    class Elk : Smeshariki
    {
        public override string Name { get; set; } = "Losyash";
        public override string Color { get; set; } = "Orange";

        public override void Voice()
        {
            Console.WriteLine("Любимая фраза - Это не научно");
        }
    }
}
