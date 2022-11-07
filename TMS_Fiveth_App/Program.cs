using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace TMS_Fiveth_App
{
    struct Point
    {
        private int x;
        private int y;
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
    }
    interface IMoveable
    {
        void Move(int x,int y);
        Point Points { get; set; }
    }
    class Person : IMoveable
    {
        public Person(Point points)
        {
            Points = points;
        }

        public Point Points { get; set; }
        public void Move(int x, int y)
        {
            Points = new Point(x,y);
        }
    }
    class Bike : IMoveable
    {
        public Bike(Point points)
        {
            Points = points;
        }

        public Point Points { get; set; }
        public void Move(int x, int y)
        {
            Points = new Point(x, y);
        }
    }
    class Car : IMoveable
    {
        public Car(Point points)
        {
            Points = points;
        }

        public Point Points { get; set; }
        public void Move(int x, int y)
        {
            Points = new Point(x, y);
        }
    }
    static class DistanceCalc
    {
        public static void CalcBetween(IMoveable firstObj, IMoveable secondObj)
        {
            Console.WriteLine(Math.Sqrt(Math.Pow(firstObj.Points.GetX - secondObj.Points.GetX, 2) +
                            + Math.Pow(firstObj.Points.GetY - secondObj.Points.GetY, 2)));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(new Point(12, 24));
            Bike b = new Bike(new Point(34, 56));
            Car c = new Car(new Point(100, 200));
            DistanceCalc.CalcBetween(p, b);
            DistanceCalc.CalcBetween(p, c);
            DistanceCalc.CalcBetween(c, b);
        }     
    }
}