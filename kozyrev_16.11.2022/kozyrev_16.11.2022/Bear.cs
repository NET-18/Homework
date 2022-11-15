using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozyrev_16._11._2022
{
    class Bear : Smeshariki
    {
        public override string Name { get; set; } = "Kopatych";
        public override string Color { get; set; } = "Brown";

        public override void Voice()
        {
            Console.WriteLine("Любимая фраза - Укуси меня пчела");
        }
    }
}
