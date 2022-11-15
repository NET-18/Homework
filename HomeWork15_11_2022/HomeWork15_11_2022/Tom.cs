using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15_11_2022
{
     class Tom : Person
    {
        public override int MaxSpeed { get; set; } = 50;
        public override int MinSpeed { get; set; } = 0;

        public Tom()
        {
            MaxSpeed = 50;
            MinSpeed = 0;
        }

        public override void DoStuff() => Console.WriteLine("I'm Tom");
        


    }
}
