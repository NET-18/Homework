using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class Person : IMovable
    {
        public Point Point { get; set; }
        void IMovable.Move(Point newLocation)
        {
            Point = newLocation;
        }
    }
}
