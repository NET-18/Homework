using System.Drawing;
using System.Reflection.Metadata;

namespace HM_26_10_2022
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            PrintInfoAboutPerson(person);
            Point3D point1 = new Point3D();
            Point3D point2 = new Point3D();
            Console.WriteLine($"Distance between points equals {Distance(point1, point2)}.");
        }

        private static void PrintInfoAboutPerson(Person person)
        {
            Console.WriteLine($"{person.surname} {person.name} is {person.age} years old.");
        } 
        private static double Distance(Point3D point1, Point3D point2)
            => Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) +
                         Math.Pow(point1.Z - point2.Z, 2));
    }
}