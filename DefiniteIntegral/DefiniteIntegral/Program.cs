namespace DefiniteIntegral
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int n;
            double a, b;
            System.Console.Write("Enter degree of polynom: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                System.Console.WriteLine("Invalid number. Try again. It's must be a non-negative integer.");
                System.Console.Write("Enter degree of polinom: ");
            }

            System.Console.WriteLine("Enter intervals.");

            System.Console.Write("Enter a: ");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                System.Console.WriteLine("Invalid number. Try again. It's must be a real number.");
                System.Console.Write("Enter a: ");
            }

            System.Console.Write("Enter b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                System.Console.WriteLine("Invalid number. Try again. It's must be a real number.");
                System.Console.Write("Enter b: ");
            }

            double[] coefficients = InputCoefficients(n);
            double result = DefiniteIntegralOfPolinom(a, b, coefficients);
            Console.Write("Definite integral of polinom ");
            for (int i = n; i >= 0; i--)
            {
                Console.Write(i == 0 ? coefficients[i] + "x^" + i : coefficients[i] + "x^" + i + " + ");
            }
            System.Console.WriteLine($" is equal {result}");
        }

        private static double DefiniteIntegralOfPolinom(double a, double b, double[] coefficients)
        {
            double result = 0.0;

            for (var i = coefficients.Length - 1; i >= 0; i--)
            {
                result += coefficients[i] * ((Math.Pow(b, i + 1) - Math.Pow(a, i + 1))) / (i + 1);
            }

            return result;
        }

        private static double[] InputCoefficients(int n)
        {
            double[] coefficients = new double[n + 1];

            for (int i = n; i >= 0; i--)
            {
                Console.Write("Enter coefficient for x^" + i + ": ");
                if (!double.TryParse(Console.ReadLine(), out coefficients[i]))
                {
                    Console.WriteLine("Wrong coefficient. Try again. It's must be a real number!");
                    ++i;
                }
            }

            return coefficients;
        }
    }
}