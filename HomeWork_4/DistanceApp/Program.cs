﻿namespace DistanceApp
{
   
    internal class Program
    {
        struct Solid
        {
            public Double x_1;
            public Double x_2;
            public Double y_1;
            public Double y_2;
            public Double z_1;
            public Double z_2;
        }
        static void Main(string[] args)
        {
            Solid a = new Solid();
            Console.Write("Введите переменную х для точки А: ");
            a.x_1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную y для точки А: ");
            a.y_1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную z для точки А: ");
            a.z_1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную х для точки Б: ");
            a.x_2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную y для точки Б: ");
            a.y_2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите переменную z для точки Б: ");
            a.z_2 = Convert.ToDouble(Console.ReadLine());

            EnterValue(a.x_1, a.y_1, a.z_1, a.x_2, a.y_2, a.z_2);
        }

        static void EnterValue(double x_1, double y_1, double z_1, double x_2, double y_2, double z_2)
        {
            
            double result = Math.Sqrt(Math.Pow(x_2 - x_1, 2) + Math.Pow(y_2 - y_1, 2) + Math.Pow(z_2 - z_1, 2));
            Console.Write(result);


        }
    }
}