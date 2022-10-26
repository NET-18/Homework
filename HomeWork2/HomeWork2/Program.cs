using System;
using System.Xml.Linq;

namespace HomeWork2
{
    public class Person
    {
        public int age;
        public string? name;
        public string? surname;

        public Person()
        {
            age = 10;
            name = "Someone";
            surname = "Something";
        }

        public Person(int a1, string? a2, string? a3)
        {
            age = a1;
            name = a2;
            surname = a3;
        }
        public override string ToString() => $"{name} {surname} is {age} years old";
    }

    public struct Point
    {
        public double x;
        public double y;
        public double z;

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() => $"{{X={x}, Y={y}, Z={z}}}";

    }

    internal class Program
    {
        public static void Print(Person person)
        {
            Console.WriteLine(person);
        }
        
              
        public static double Distance(Point a, Point b)
        {
            double dX = a.x - b.x;
            double dY = a.y - b.y;
            double dZ = a.z - b.z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }
        
        static void Main(string[] args)
        {
            Person person = new(23, "Vivienne", "Storm");
            Print(person);

            Point point1 = new Point(3, 7, 16);
            Point point2 = new Point(7, 3, 5);

            Console.WriteLine($"Расстояние от точки {point1} до точки {point2} равно {Distance(point1,point2)}");

            Console.ReadKey();
        }
    }


}