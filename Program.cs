namespace ConsoleApp4
{
    
    internal class Program
    {
        static void Main(string[] args)
        {

            var myCollection = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7
            };
            myCollection.Add(1);

            var myCollection = new MyCollection();
            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }  

    }
}