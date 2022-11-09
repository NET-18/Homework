namespace ConsoleApp1
{
    internal class Bike : IMovable
    {
        public Point point { get; set; }

        public void Move()
        {
            Point newPoint = new();
            point = newPoint;
            Console.WriteLine("Bike");
        }

        public Bike() 
        {
            point = new();
        }

    }
}
