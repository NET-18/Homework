
namespace ConsoleApp1
{
    public static class Distance
    {
        public static void GetDistance(int carX, int carY, int bikeX, int bikeY, int personX, int personY) 
        {
            Console.WriteLine("\nDistance between CAR and BIKE:\n");
            double a = Math.Sqrt(Math.Pow(Convert.ToDouble(carX) - Convert.ToDouble(bikeX), 2) +
                Math.Pow(Convert.ToDouble(carY) - Convert.ToDouble(bikeY), 2));
            Console.WriteLine(Convert.ToInt32(a));

            Console.WriteLine("\nDistance between PERSON and BIKE:\n");
            a = Math.Sqrt(Math.Pow(Convert.ToDouble(personX) - Convert.ToDouble(bikeX), 2) +
                Math.Pow(Convert.ToDouble(personY) - Convert.ToDouble(bikeY), 2));
            Console.WriteLine(Convert.ToInt32(a));

            Console.WriteLine("\nDistance between PERSON and CAR:\n");
            a = Math.Sqrt(Math.Pow(Convert.ToDouble(personX) - Convert.ToDouble(carX), 2) +
                Math.Pow(Convert.ToDouble(carY) - Convert.ToDouble(carY), 2));
            Console.WriteLine(Convert.ToInt32(a));
        }
    }
}
