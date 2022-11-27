using System.IO;

namespace HW_12
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var myPath = "note.txt";

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            
            PrintSmthing();
            await Task.Delay(1000);
            Thread.Sleep(1000);

            Console.WriteLine("Type now!");
            string? myText = Console.ReadLine();
            
            await FileWriteAsync(myText, myPath);
            myText = await FileReadAsync(myPath);
            Console.WriteLine(myText);
            

            Console.WriteLine("OVER???");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    
        static async Task PrintSmthing()
        {
            for (int i = 0; i < 10; i++)
            {
                
                Console.WriteLine($"So fucking hard...[{Thread.CurrentThread.ManagedThreadId}]");
                await Task.Delay(500);
            }
        }

        static async Task FileWriteAsync(string text, string filePath)
        {
            await File.WriteAllTextAsync(filePath, text);
        }

        static async Task<String> FileReadAsync(string filePath)
        {
            string text = await File.ReadAllTextAsync(filePath);
            return text;
        }
    }
}