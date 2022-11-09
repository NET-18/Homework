namespace ConsoleApp1
{
    internal class Person : IMovable 
    {
        public Point point { get ; set ; }

        public void Move()
        {
            Point newPoint = new();
            point = newPoint;
            Console.WriteLine("Person");
        }

        public Person()  
        {
            point = new();
        }
    }
}
