using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Car : IMovable
    {
        public Point _point { get; set; }


        public void Move()
        {
            Random rnd = new Random();
            double x3 = _point.x + rnd.Next(1, 10);
            double y3 = _point.y + rnd.Next(1, 10);
            Console.WriteLine($"Car coordinates : [{x3},{y3}]");
        }
    }
}
