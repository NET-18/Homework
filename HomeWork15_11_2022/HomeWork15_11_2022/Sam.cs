using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15_11_2022
{
      class Sam : Person
    {
        public override int MaxSpeed { get; set; } = 1;
        public override int MinSpeed { get; set; } = 20;

        public Sam()
        {
            MaxSpeed = 20;
            MinSpeed = 1;
        }

        public override void DoStuff() => Console.WriteLine("I'm Sam");
    }
}
