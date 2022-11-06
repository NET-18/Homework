namespace HomeWork_09_11_2022
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person me = new Person("Sergey", 20, new Point(0, 0));
            Bike myBike = new Bike("Yamaha", 300, new Point(3, 4));
            Car myCar = new Car("Lamborghini", 450, 7, new Point(6, 8));

            Console.WriteLine($"Distance between me and my bike equal " + StaticClass.Distance(me, myBike));
            Console.WriteLine($"Distance between me and my car equal " + StaticClass.Distance(me, myCar));
            Console.WriteLine($"Distance between my bike and my car equal " + StaticClass.Distance(myCar, myBike));
        }
    }
}