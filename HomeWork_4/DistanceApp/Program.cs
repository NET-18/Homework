namespace DistanceApp
{

    internal class Program
    {
        public struct Solid
        {
            public Double x;
            public Double y;
            public Double z;
        }
        static void Main()
        {
            Solid a1 = new Solid();
            Solid a2 = new Solid();
            Console.Write("Введите переменную х для точки А: ");
            a1.x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную y для точки А: ");
            a1.y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную z для точки А: ");
            a1.z = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную х для точки Б: ");
            a2.x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную y для точки Б: ");
            a2.y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную z для точки Б: ");
            a2.z = Convert.ToDouble(Console.ReadLine());

            EnterValue(a1, a2);
        }

        static void EnterValue(Solid a1, Solid a2)
        {

            double result = Math.Sqrt(Math.Pow(a2.x - a1.x, 2) + Math.Pow(a2.y - a1.y, 2) + Math.Pow(a2.z - a1.z, 2));
            Console.Write(result);


        }
    }
}