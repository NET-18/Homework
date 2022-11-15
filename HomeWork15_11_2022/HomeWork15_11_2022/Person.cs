using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15_11_2022
{
     public abstract class Person
    {
        public abstract int MaxSpeed { get; set; }
        public abstract int MinSpeed { get; set; }

        public virtual void Move(int x, int y)
        {
            Console.WriteLine($"I'm moving to ({x},{y}");
        }
        public abstract void DoStuff();
    }
}
