﻿namespace ConsoleApp8
{
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x; this.y = y;
        }
    }
    public interface IMovable
    {
        void Move(int x, int y);

        Point point { set; get; }
    }
    public class Person : IMovable
    {
        Point points = new Point();

        public void Move(int x, int y)
        {
            points.x = x;
            points.y = y;
        }
        public Point point
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
    }
    public class Bike : IMovable
    {
        Point points = new Point();

        public void Move(int x, int y)
        {
            points.x = x;
            points.y = y;
        }
        public Point point
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

    }
    public class Car : IMovable
    {
        Point points = new Point();
        public Point point
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
        public void Move(int x, int y)
        {
            points.x = x;
            points.y = y;
        }
    }
    public static class Calculations
    {
        public static void Delta(IMovable movable1, IMovable movable2)
        {
            double d = Math.Sqrt(Math.Pow((movable1.point.x - movable2.point.x), 2) + Math.Pow((movable1.point.y - movable2.point.y), 2));

            Console.WriteLine($"Delta between Movable1 and Movable2 is {d}");
        }
        public static void Move1To2(IMovable movable1, IMovable movable2)
        {
            movable1.Move(movable2.point.x, movable2.point.y);
        }
        public static void Move2To1(IMovable movable1, IMovable movable2)
        {
            movable2.Move(movable1.point.x, movable1.point.y);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Person Ivan = new Person();

            Ivan.Move(5, 6);
            Console.WriteLine(Ivan.point.x);

            Car Lambada = new Car();

            Lambada.Move(16, 6);
            Console.WriteLine($"Lambada.x ={Lambada.point.x}");
            Console.WriteLine($"Lambada.y ={Lambada.point.y}");

            Calculations.Delta(Lambada, Ivan);
            Calculations.Move1To2(Lambada, Ivan);

            Console.WriteLine($"Lambada.x ={Lambada.point.x}");
            Console.WriteLine($"Lambada.y ={Lambada.point.y}");

        }

    }


}