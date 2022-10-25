using System;
using System.Security.Cryptography;

namespace TMS_First_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 3 числа: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Sum(a, b, c));
            Console.WriteLine(Sub(a, b, c));
            Console.WriteLine(Mult(a, b, c));
            Console.WriteLine(Div(a, b, c));  
            
        }
        static int Sum(int a,int b,int c)
        {
            int sum = a + b + c;
            return sum;
        }
        static int Sub(int a, int b, int c)
        {
            int sub = a - b - c;
            return sub;
        }
        static int Mult(int a, int b, int c)
        {
            int mult = a * b * c;
            return mult;
        }
        static double Div(int a, int b, int c)
        {
            double div = (double)a / (double)b / (double)c;
            return div;
        }

    }
}