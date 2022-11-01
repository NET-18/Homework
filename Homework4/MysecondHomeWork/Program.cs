using System.Security.Cryptography.X509Certificates;

namespace MysecondHomeWork
{
    internal class Program
    {
        struct Space
        {
            public double _x;
            public double _y;
            public double _z;
        }

        static void Main(string[] args)
        {
            Space star = new Space();
            Console.Write("Введите значение x для точки А: ");
            star._x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение у для точки А: ");
            star._y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение z для точки А: ");
            star._z = Convert.ToDouble(Console.ReadLine());
            Space cosmo = new Space();
            Console.Write("Введите значение x для точки B: ");
            cosmo._x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение y для точки B: ");
            cosmo._y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение z для точки B: ");
            cosmo._z = Convert.ToDouble(Console.ReadLine());
            Rasst(cosmo, star);
        }
        static void Rasst(Space star, Space cosmo)
        {
            double resXY = Math.Sqrt(Math.Pow(cosmo._x - star._x, 2) + Math.Pow(cosmo._y - star._y, 2) + Math.Pow(cosmo._z - star._z, 2));
            Console.WriteLine("Расстояние между точками " + resXY);
        }

    }
}