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

            for (; x > 0; x--)
            {
                Load += 1;
                if (Load >= MaxLoad)
                {
                    x--;
                    break;
                }
            }

            if (x == 0)
            {
                Console.WriteLine("no bullets left");
            }

            if (Load == MaxLoad)
            {
                Console.WriteLine("Load = MaxLoad, {0} bullets left", x);
            }
            Console.WriteLine("Load =  {0}", Load);
        }
        public virtual void Fire(int x)
        {
            Load -= RateOfFire * x;
            Console.WriteLine("I fired {0} times", x);
            Console.WriteLine("Load =  {0}", Load);
        }
        public abstract void Info();
    }
}
