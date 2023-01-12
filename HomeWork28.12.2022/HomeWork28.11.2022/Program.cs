using System;
using System.Diagnostics;

namespace HomeWork28._12._2022
{
    internal class Program
    {
        public static async Task PrintAsync()
        {
            for(int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.WriteLine("что-то");
            }
        }
        async static Task Main(string[] args)
        {    
            PrintAsync();
            await Task.Delay(2000);
            Console.WriteLine("async await");
            Thread.Sleep(2000);
            Console.WriteLine("end");

            Console.WriteLine("введите текст который хотите сохранить в файл");
            string text = Console.ReadLine();

            await File.WriteAllTextAsync(@"C:\Users\Nikita\Desktop\test.txt", text);

            Console.WriteLine("Text was written...");

            Console.ReadKey();

            string filePath = @"C:\Users\Nikita\Desktop\test.txt";
            string text1 = await File.ReadAllTextAsync(filePath);

            Console.WriteLine(text1);
            
        }
    }
    
}