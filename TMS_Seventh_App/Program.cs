namespace TMS_Seventh_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList();
            foreach (var item in myList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n");

            var newList = new List<MyNewClass>()
            {
                new MyNewClass(1),
                new MyNewClass(4),
                new MyNewClass(10),
                new MyNewClass(6),
                new MyNewClass(7)
            };

            foreach (var item in newList)
            {
                Console.WriteLine(item.Number);
            }

            newList.Sort();
            Console.WriteLine();

            foreach (var item in newList)
            {
                Console.WriteLine(item.Number);
            }
        }
    }
}