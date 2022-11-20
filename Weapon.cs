using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal abstract class Weapon
    {
        public abstract int MaxLoad { get; set; }
        public abstract int Load { get; set; }
        public abstract int RateOfFire { get; set; }
        public virtual void Loading(int x)
        {
            Load = Load + x;
            
            if (MaxLoad == Load)
            {
                Console.WriteLine("no bullets left");
            }

            if (Load > MaxLoad)
            {
                Console.WriteLine("Load = MaxLoad, {0} bullets left", Load - MaxLoad);
                Load = MaxLoad;
            }
            else
            {
                Console.WriteLine("Load =  {0}", Load);
            }
        }
        public virtual void Fire(int x)
        {
            Console.WriteLine("Weapon Is Fire!!!");
            for (int i = 1; i <= x; i++)
            {
                Load -= RateOfFire;
                Console.WriteLine("I fire {0} time", i);
                Console.WriteLine("Load =  {0}", Load);
                if (Load == 0)
                {
                    Console.WriteLine("No more bullets");
                    break;
                }
            }
        }
        public abstract void Info();
    }
}
