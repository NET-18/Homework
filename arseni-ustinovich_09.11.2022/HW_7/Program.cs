using static System.Math;

namespace HW_7
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }
    interface IMovable
    {
        Point Point { get; set; }
        void Move(Point point);
    }
    public class MyObject : IMovable
    {
        public Point Point { get; set; }

        public MyObject(Point newPoint)
        {
            Point = newPoint;
        }

        public MyObject(int x, int y)
            : this(new Point(x, y)) { }

        public MyObject()
            : this(0, 0) { }

        public void Move(Point endPoint)
        {
            Point = endPoint;
        }
        public void Move(int x, int y)
        {
            Point = new Point(x, y);
            Console.WriteLine("Moving...");
        }
        public void PrintInfo(string name)
        {
            Console.WriteLine($"Current coordinates of {name} are x - {Point.x} y - {Point.y}");
        }
    }
    public sealed class Person : MyObject, IMovable
    {   
        public Person(Point point)
        : base(point) { }
        public Person(int x, int y)
            : base(x, y) { }
        public Person()
            : base() { }
    }
    public sealed class Bike : MyObject, IMovable
    {
        public Bike(Point point)
        : base(point) { }
        public Bike(int x, int y)
            : base(x, y) { }
        public Bike()
            : base() { }
    }

    public sealed class Car : MyObject, IMovable
    {
        public Car(Point point)
        : base(point) { }
        public Car(int x, int y)
            : base(x, y) { }
        public Car()
            : base() { }
    }

    static class Points
    {
        public static double Calc(IMovable fObj, IMovable sObj) => Calc(fObj.Point.x, fObj.Point.y, sObj.Point.x, sObj.Point.y);
        public static double Calc(int x1, int y1, int x2, int y2) => Sqrt(Pow(x1 - x2, 2) + Pow(y1 - y2, 2));
        public static double Calc(IMovable fObj, int x, int y) => Calc(fObj.Point.x, fObj.Point.y, x, y);
    }

    internal class Program
    {
        static void Main()
        {
            Person myPerson = new(15, 50);
            myPerson.PrintInfo("Person");
            myPerson.Move(10, 10);
            myPerson.PrintInfo("Person");

            Car myCar = new(new Point(40, 40));
            myCar.PrintInfo("Car");

            Bike myBike = new();
            myBike.PrintInfo("Bike");

            Console.WriteLine($"Distance between Person and Bike is {Points.Calc(myPerson, myBike):f2}");

            Console.WriteLine($"Distance between Person and Car is {Points.Calc(myPerson, myCar.Point.x, myCar.Point.y):f2}");

            Console.WriteLine($"Distance between Bike and Car is {Points.Calc(myBike.Point.x, myBike.Point.y, myCar.Point.x, myCar.Point.y):f2}");
        }
    }
}