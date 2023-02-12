namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<MyClass>();
            var obj1 = new MyClass(3);
            var obj2 = new MyClass(10);
            var obj3 = new MyClass(6);
            var obj4 = new MyClass(1);

            myList.Add(obj1);
            myList.Add(obj2);
            myList.Add(obj3);
            myList.Add(obj4);

            foreach (var item in myList)
            {
                Console.WriteLine(item.Count);
            }

            myList.Sort();

            foreach (var item in myList)
            {
                Console.WriteLine(item.Count);
            }


            var firstList = new MyList(new MyClass[] { obj1, obj2 });            
            Console.WriteLine($"Size: {firstList.Size}");
            Console.WriteLine($"Capacity: {firstList.Capacity}");
            firstList.Capacity = 1;
            Console.WriteLine($"Capacity: {firstList.Capacity}");

            foreach (var item in firstList)
            {
                
            }

            firstList.MyObjects[1] = obj3;

        }
    }
}