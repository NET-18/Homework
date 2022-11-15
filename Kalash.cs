using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class Kalash : Weapon
    {
        public override int MaxLoad { get; set; } = 30;
        public override int Load { get; set; } = 0;
        public override int RateOfFire { get; set; } = 2;

        public override void DoStuff()
        {
            Console.WriteLine("I'm Kalash, my Load is {0}, my max Load is {1}, my Rate Of Fire is {2}", Load, MaxLoad, RateOfFire);
        }
    }
}
