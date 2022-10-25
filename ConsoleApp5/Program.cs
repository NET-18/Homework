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
        public static void Main()
        {
            void Print()
            {
                Person Joash = new Person();
                Console.WriteLine($"{Joash.name} {Joash.surname} is {Joash.age} years old");
            }
            Print();
            void length(double x1, double y1, double z1, double x2, double y2, double z2)
            {
                Koordinates point1 = new(x1, y1, z1);
                Koordinates point2 = new(x2, y2, z2);
                double k = Math.Sqrt(Math.Pow((point1.x - point2.x), 2) + Math.Pow((point1.y - point2.y), 2) + Math.Pow((point1.z - point2.z), 2));
                Console.WriteLine($"Расстояние между точками - {k}");
            }
            length(0,0,0,0,0,0);
        }

    }
}
    
