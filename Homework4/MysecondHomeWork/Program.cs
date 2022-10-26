namespace MysecondHomeWork
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Space star = new Space();
            Console.Write("Введите значение x для точки А");
            star.x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение у для точки А");
            star.y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение z для точки А");
            star.z = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение x1 для точки B");
            star.x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение у1 для точки B");
            star.y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите значение z1 для точки B");
            star.z1 = Convert.ToDouble(Console.ReadLine());
            Rasst(star.x, star.y, star.z, star.x1, star.y1, star.z1);
        }
        static void Rasst(double x, double y, double z, double x1, double y1, double z1)
        {
            double resXY = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2) + Math.Pow(z1 - z, 2));
            Console.WriteLine("Расстояние между точками " + resXY);
        }
        struct Space
        {
            public double x;
            public double y;
            public double z;
            public double x1;
            public double y1;
            public double z1;
        }

    }
}