namespace Homework5
{
    public struct Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public interface IMovable
    {
        public Point _point { get; set; }

        public void Move()
        {
            Random rnd = new Random();
            double x1 = _point.x + rnd.Next(1, 10);
            double y1 = _point.y + rnd.Next(1, 10);
        }
    }
    
    internal class Program
    {
        public static double Distance(IMovable a, IMovable b)
        {
            double dX = a._point.x - b._point.x;
            double dY = a._point.y - b._point.y;
            return Math.Sqrt(dX * dX + dY * dY);
        }
        static void Main(string[] args)
        {
            Point point = new Point(3, 7);

            Person person = new Person();
            person._point = new Point(7, 5);  
            person.Move();

            Car car = new Car();
            car._point = new Point(6, 2);
            car.Move();

            Bike bike = new Bike();
            bike._point = new Point(1, 3);
            bike.Move();

            
            Console.WriteLine(Distance(person, car));
            Console.WriteLine(Distance(person, bike));
        }
    }
}