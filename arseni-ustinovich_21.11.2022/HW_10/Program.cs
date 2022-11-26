namespace HW_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new(new int[] {1, 5, 9, 7, 9, 10});

            myList.Add(1);
            
            myList.Add(5);

            myList.Remove(9);

            myList.Add(new int[] { 55, 55});

            myList.Insert(2, new int[] {10,10,10});

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}