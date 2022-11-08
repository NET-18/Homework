namespace ConsoleApp8
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

        Point Point { set; get; }
    }
    public class Person : IMovable
    {
        Point Points = new Point();

        public void Move(int x, int y)
        {
            Points.x = x;
            Points.y = y;
        }
        public Point Point
        {
            get
            {
                return Points;
            }
            set
            {
                Points = value;
            }
        }
    }
    public class Bike : IMovable
    {
        Point Points = new Point();

        public void Move(int x, int y)
        {
            Points.x = x;
            Points.y = y;
        }
        public Point Point
        {
            get
            {
                return Points;
            }
            set
            {
                Points = value;
            }
        }

    }
    public class Car : IMovable
    {
        Point Points = new Point();
        public Point Point
        {
            get
            {
                return Points;
            }
            set
            {
                Points = value;
            }
        }
        public void Move(int x, int y)
        {
            Points.x = x;
            Points.y = y;
        }
    }
    public static class Calculations
    {
        public static void Delta(IMovable Movable1, IMovable Movable2)
        {
            double d = Math.Sqrt(Math.Pow((Movable1.Point.x - Movable2.Point.x), 2) + Math.Pow((Movable1.Point.y - Movable2.Point.y), 2));

            Console.WriteLine($"Delta between Movable1 and Movable2 is {d}");
        }
        public static void Move1To2(IMovable Movable1, IMovable Movable2)
        {
            Movable1.Move(Movable2.Point.x, Movable2.Point.y);
        }
        public static void Move2To1(IMovable Movable1, IMovable Movable2)
        {
            Movable2.Move(Movable1.Point.x, Movable1.Point.y);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Person Ivan = new Person();

            Ivan.Move(5, 6);
            Console.WriteLine(Ivan.Point.x);

            Car Lambada = new Car();

            Lambada.Move(16, 6);
            Console.WriteLine($"Lambada.x ={Lambada.Point.x}");
            Console.WriteLine($"Lambada.y ={Lambada.Point.y}");

            Calculations.Delta(Lambada, Ivan);
            Calculations.Move1To2(Lambada, Ivan);
            Console.WriteLine($"Lambada.x ={Lambada.Point.x}");
            Console.WriteLine($"Lambada.y ={Lambada.Point.y}");

        }

    }


}