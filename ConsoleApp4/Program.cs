namespace ConsoleApp4
{
    internal class Program
    {
        static void summury(double a, double b)
        {
            double c = a + b;
            Console.WriteLine($"Сумма ={c}");
        }
        static void difference(double a, double b)
        {
            double c = a - b;
            Console.WriteLine($"Разность ={c}");
        }
        static void muliply(double a, double b)
        {
            double c = a * b;
            Console.WriteLine($"Произведение ={c}");
        }
        static void division(double a, double b)
        {
            double c = a / b;
            Console.WriteLine($"Частное ={c}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два целых числа через пробел");
            string line = Console.ReadLine();
            string[] splitString = line.Split(' ');

            double x1 = double.Parse(splitString[0]);
            double x2 = double.Parse(splitString[1]);

            summury(x1, x2);
            difference(x1, x2);
            muliply(x1, x2);
            division(x1, x2);

            double integral(double a)
            {
                double c = ((Math.Pow(a,3) / 3) + 16 * a);
                return c;
            }
            var c1 = integral(x1) - integral(x2);
            Console.WriteLine($"Итеграл от {x1} до {x2} равен  {c1}");
        }
    }
}