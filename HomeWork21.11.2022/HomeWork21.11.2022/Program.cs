
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork21._11._2022
{
    internal class Program 
    {

        static void Main(string[] args)
        {
            var arr = new MyList<int>(new int[] {1, 2, 3, 4, 5, 6, 7});
            foreach (int i in arr) 
            {
                Console.WriteLine(i);
            }
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);
            arr.Add(11);
            arr.Add(12);
            arr.Add(13);
            arr.Add(14);
            arr.Add(15);
            arr.Add(16);
            Console.WriteLine(arr.size);
            Console.WriteLine(arr.capasity);
            //Console.WriteLine(arr.capacity);

            //var bambers = new List<int>() { 1, 2, 3, 4, 65, 45, 45, 56 };
            //bambers.Sort();
            //foreach(int i in bambers)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(bambers);
            
            
            
            
        }
    }
}