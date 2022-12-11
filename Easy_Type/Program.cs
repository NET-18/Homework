namespace ConsoleApp6
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    class Program
    {
        public static async Task SimpleWriteAsync(List<Task<string>> tasks)
        {
            Console.WriteLine("SimpleWriteAsync Start");
            string filePath = "RandomWords.txt";
            string text = "";
            foreach (var item in tasks)
            {
                  text += item.Result + "\n\n";
            }
            await File.WriteAllTextAsync(filePath, text);
            Console.WriteLine("SimpleWriteAsync End");
        }
        public static string StringRandom(int v, int j)
        {
            //Console.WriteLine("StringRandom Start");
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[v];
            var random = new Random();
            for (int i = 0; i < v; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            Task.Delay(random.Next(100)).Wait();
            var s = new string(stringChars);
            Console.Write($"{j},\t");
            return s;
        }
        static void Main(string[] args)
        {
            int v = 1000;
            int j=0;
            List<Task<string>> tasks = new List<Task<string>>(v);
            
            for (int i = 0; i <= v; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => StringRandom(v, j++)));
            }

            Task.WhenAll(tasks).Wait();
            SimpleWriteAsync(tasks).Wait();
            Console.ReadLine();
        }
    }
}