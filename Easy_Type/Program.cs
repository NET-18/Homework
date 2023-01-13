namespace ConsoleApp6
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    class Program
    {
        public static async Task SimpleWriteAsync(List<Task<string>> tasks)
        {
            Console.WriteLine($"SimpleWriteAsync Start");
            int j = 1;

            foreach (var item in tasks)
            {
              await File.WriteAllTextAsync($"RandomWords{j++}.txt", item.Result);
            }
        }

        public static async Task<string> StringRandom(int v, int j)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[v];
            var random = Random.Shared;

            for (int i = 0; i < v; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            await Task.Delay(random.Next(100));
            var s = new string(stringChars);
            Console.Write($"{j},\t");
            
            return s;
        }

        static async Task Main(string[] args)
        {
            var timeStart = DateTime.Now;
            int valueMax = 1000;
            int numberTask = 0;
            List<Task<string>> tasks = new List<Task<string>>(valueMax);

            for (int i = 0; i <= valueMax; i++)
            {
                tasks.Add(StringRandom(valueMax, numberTask++));
            }

            await Task.WhenAll(tasks);
            await SimpleWriteAsync(tasks);

            Console.WriteLine("Temelapse - {0}",DateTime.Now - timeStart);
            Console.ReadLine();
        }
    }
}