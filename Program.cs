using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp4
{
    
    internal class Program
    {
       

        static void Main(string[] args)
        {
            var myCollection = new MyList<int>(new int[] { 1, 2, 3 });

          
            myCollection.Add(1);

            

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
        }  

    }
}