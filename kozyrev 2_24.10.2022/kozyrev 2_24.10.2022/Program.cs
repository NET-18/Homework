using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace kozyrev_2_24._10._2022
{
    internal class Program
    {
        //struct Space
        //{
        //    pubic double x;
        //    pubic double y;
        //    pubic double z;
        //    pubic double x1;
        //    pubic double y1;
        //    pubic double z1;
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты x для первой точки");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты y для первой точки");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты z для первой точки");
            double z = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты x1 для первой точки");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты y1 для первой точки");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты z1 для первой точки");
            double z1 = Convert.ToDouble(Console.ReadLine());

            double rast = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2) + Math.Pow(z1 - z, 2));
            Console.WriteLine("Расстояние между точками " + rast);
        }
    }
}