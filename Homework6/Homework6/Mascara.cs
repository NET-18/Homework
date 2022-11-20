using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class Mascara : MakeUp
    {
        public override string Company { get; set; } = "Color Pop";
        public override string Color { get; set; } = "light blue";
        
        public override void MakeUpInfo()
        {
            Console.WriteLine($"Love this {Color} mascara from {Company} cosmetics!");
        }
    }
}
