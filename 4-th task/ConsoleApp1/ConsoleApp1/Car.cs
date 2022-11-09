namespace ConsoleApp1
{
    internal class Car : IMovable
    {
        public Point point { get; set; }

        public void Move()
        {
            Point newPoint = new();
            point = newPoint;
            Console.WriteLine("Car");
        }

        public Car() 
        {
            point = new();
        }

    }
}
