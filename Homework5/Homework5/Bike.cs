using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Bike : IMovable
    {
        public Point _point { get; set; }


        public void Move()
        {
            Random rnd = new Random();
            double x4 = _point.x + rnd.Next(1, 10);
            double y4 = _point.y + rnd.Next(1, 10);
            Console.WriteLine($"Bike coordinates : [{x4},{y4}]");
        }
    }
}
