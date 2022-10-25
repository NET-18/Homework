using System.Security.Cryptography.X509Certificates;

namespace TMS_Second_App
{
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
            age = 15;
            name = "John";
            surname = "Boleslava";
        }
    }
    struct Cords
    {
        public double x;
        public double y;
        public double z;
    }
    internal class Program
    {
        static void Paramms()
        {
            Person p = new Person();
            string _string = $"{p.surname} {p.name} is {p.age} years old";
            Console.WriteLine(_string);
        }
        static void Culc()
        {
            Cords cords = new Cords();
            cords.x = int.Parse(Console.ReadLine());
            cords.y = int.Parse(Console.ReadLine());
            cords.z = int.Parse(Console.ReadLine());
            double result_1 = cords.x - cords.y;
            double result_2 = cords.z - cords.y;
            double result_3 = cords.z - cords.x;
            Console.WriteLine(Math.Abs(result_1));
            Console.WriteLine(Math.Abs(result_2));
            Console.WriteLine(Math.Abs(result_3));
        }
        static void Main(string[] args)
        {
            Paramms();
            Console.WriteLine();
            Culc();
        }
    }
}