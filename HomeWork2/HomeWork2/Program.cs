using System.Xml.Linq;

namespace HomeWork2
{
    public class Person
    {
        public int age;
        public string? name;
        public string? surname;

        public Person(int a1, string? a2, string? a3)
        {
            age = a1;
            name = a2;
            surname = a3;
        }


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

        
    }

    internal class Program
    {
        public static void Print(Person person)
        {
            Console.WriteLine($"{person.name} {person.surname} is {person.age} years old");
        }
        
        
        public double x;
        public double y;
        public double z;

        public Program(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static double Distance(Program a, Program b)
        {
            double dX = a.x - b.x;
            double dY = a.y - b.y;
            double dZ = a.z - b.z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }

        public override string ToString() => $"{{X={x}, Y={y}, Z={z}}}";

        public double Distance(Program otherPoint) => Distance(this, otherPoint);

        static void Main(string[] args)
        {
            Person person = new(23, "Vivienne", "Storm");
            Print(person);

            Program point1 = new Program(3, 7, 16);
            Program point2 = new Program(7, 3, 5);

            Console.WriteLine($"Расстояние от точки {point1} до точки {point2} равно {point1.Distance(point2)}");

            Console.ReadKey();
        }
    }


}