using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class Lipstick : MakeUp
    {
        public override string Company { get; set; } = "Jeffree Star";
        public override string Color { get; set; } = "purple";

        public override void MakeUpInfo()
        {
            Console.WriteLine($"Adore this {Color} mascara from {Company} cosmetics!");
        }
    }
}
