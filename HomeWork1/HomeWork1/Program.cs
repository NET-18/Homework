using System.Xml.Linq;

namespace HomeWork1
{
    internal class Program
    {
        static int Sum(int a, int b)
        {
            int add = a + b;
            return add;
        }

        static int Sub(int a, int b)
        {
            int sub = a - b;
            return sub;
        }

        static int Multiply(int a, int b)
        {
            int mult = a * b;
            return mult;
        }

        static double Divide(int a, int b)
        {
            double div = (double)a / b;
            return div;
        }
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());

            /*Sum(a, b);
            Sub(a, b);
            Multiply(a, b);
            Divide(a, b);*/

            Console.WriteLine($"Сумма: {Sum(a, b)},  Вычитание: {Sub(a, b)},  Умножение: {Multiply(a, b)}, Деление: {Divide(a, b)}");

        }


    }
}