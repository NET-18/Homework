namespace test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point x = new Point();
            Point x1 = new Point();
            Point y = new Point();
            Point y1 = new Point();
            Point z = new Point();
            Point z1 = new Point();

            Point distance = new Point();
            distance = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2) + Math.Pow(z1 - z, 2));
            Console.WriteLine(distance.ToString()); 
        }
    }
}