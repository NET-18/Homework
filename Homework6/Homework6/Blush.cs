using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class Blush : MakeUp
    {
        public override string Company { get; set; } = "MAC";
        public override string Color { get; set; } = "peach";

        public override void MakeUpInfo()
        {
            Console.WriteLine($"I'm obsessed with this {Color} blush from {Company} cosmetics!");
        }
    }
}
