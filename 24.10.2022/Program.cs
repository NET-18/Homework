using System.Diagnostics.CodeAnalysis;

namespace _24._10._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter next number");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Summury = {Summury}, Subtraction = {Subtraction}");
            Console.WriteLine($"Multiplication  = {Multiplication}, Division = {Division}");


            static int Summury(int a, int b);
            { 
                int sum = a + b; 
            }

            static int Subtraction(int a, int b);
            {
                int sub = a - b;
            }
            static int Multiplication(int a, int b);
            {
                int mult = a * b;
            }
            static int Division(int a, int b);
            {
                int div = a / b;
            }

        }

    }
}