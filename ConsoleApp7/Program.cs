using System.Reflection;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var randgend = Random.Shared.Next(0,1);
            var rand2 = Random.Shared.Next(0,6);
            var arr1 = new int[2, 7] { { 1, 2, 3, 4, 5, 6, 7 }, { 8, 9, 10, 11, 12, 13, 14 } };
            var len = arr1.Length;
            Console.WriteLine(arr1[randgend, rand2]);
            var gender = "Female";
            if (randgend == 0)
            {
                gender = "Male";
            }
        }
    }
}