using System.ComponentModel.Design;
using System.Text;

namespace Homework_28._11._2022
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var printer = new NumbersPrinter();

            var tasks = new Task[5];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = printer.PrintNumbers();
                Thread.CurrentThread.Name = $"thread {i}";

            }

            await Task.Delay(500);
            Thread.Sleep(500);

            string filePath = "temp.txt";
            string? text = Console.ReadLine();

            await WriteTextAsync(filePath, text);

            await ReadTextAsync(filePath);

        }

        static async Task WriteTextAsync(string filePath, string text)
        {
            await File.WriteAllTextAsync(filePath, text);
        }

        static async Task ReadTextAsync(string filePath)
        {
            string text = await File.ReadAllTextAsync(filePath);

            Console.WriteLine(text);
        }
    }
    public class NumbersPrinter
    {

        public async Task PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name);

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.Write($"{i} ");
            }

            Console.WriteLine();

        }
    }
}