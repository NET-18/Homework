namespace ConsoleApp5
{
    using System;
    
    class Person
    {
        public int age;
        public string name;
        public string surname;

        public Person(int age, string name, string surname)
        {
            this.age = age;
            this.name = name;
            this.surname = surname;
        }
        public Person()
        {
            age = 21;
            name = "Joash";
            surname = "Lebovsky";
        }
    }
    struct Koordinates
    {
        public double x;
        public double y;   
        public double z;
        public Koordinates(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    class Program
    {
        public static void Print(Person person)
        {
          Console.WriteLine($"{person.name} {person.surname} is {person.age} years old");
        }
        public static void Length(Koordinates a, Koordinates b)
        {
            double k = Math.Sqrt(Math.Pow((a.x - b.x), 2) + Math.Pow((a.y - b.y), 2) + Math.Pow((a.z - b.z), 2));
            Console.WriteLine($"Расстояние между точками - {k}");
        }
        public static void Main(string[] args)
        {
            Person Joash = new Person();
            Print(Joash);
            Console.WriteLine("Координаты первой точки");
            string line = Console.ReadLine();
            string[] splitString = line.Split(' ');

            double x1 = Convert.ToDouble(splitString[0]);
            double y1 = Convert.ToDouble(splitString[1]);
            double z1 = Convert.ToDouble(splitString[2]);

            Console.WriteLine("Координаты второй точки");
            string line2 = Console.ReadLine();
            string[] splitString2 = line2.Split(' ');

            double x2 = Convert.ToDouble(splitString2[0]);
            double y2 = Convert.ToDouble(splitString2[1]);
            double z2 = Convert.ToDouble(splitString2[2]);

            Koordinates point1 = new(x1, y1, z1);
            Koordinates point2 = new(x2, y2, z2);
            Length(point1, point2);
        }

    }
}
    
