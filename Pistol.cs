using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class PistolMakarov : Weapon
    {
        public override int MaxLoad { get; set; } = 8;
        public override int Load { get; set; } = 0;
        public override int RateOfFire { get; set; } = 1;

        public override void DoStuff()
        {
            Console.WriteLine("I'm Makarov, my Load is {0}, my max Load is {1}, my Rate Of Fire is {2}", Load, MaxLoad, RateOfFire);
        }
    }
}
