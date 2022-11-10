using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    public class Person : IMovable
    {
        public Point _point { get; set; }


        public void Move()
        {
            Random rnd = new Random();
            double x = _point.x + rnd.Next(1, 10);
            double y = _point.y + rnd.Next(1, 10);
            Console.WriteLine($"Person coordinates : [{x},{y}]");
        }
    }
}
