namespace kozyrev_16._11._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var smesharik = new Bear();
            var smesharik2 = new Elk();


            Console.WriteLine("Имя: " + smesharik.Name);
            Console.WriteLine("Цвет: " + smesharik.Color);
            SmesharikiFactory.Process(smesharik);
            Console.WriteLine("");
            Console.WriteLine("Имя: " + smesharik2.Name);
            Console.WriteLine("Цвет: " + smesharik2.Color);
            SmesharikiFactory.Process(smesharik2);
        }
    }
}