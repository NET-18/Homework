namespace ConsoleApp1
{
    internal class Program
    {
        public static async Task Print()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.WriteLine(i);
            }
        }

        public static async Task SimpleWriteAsync(string text)
        {
            string filePath = "simple.txt";
            
            await File.WriteAllTextAsync(filePath, text);
        }

        public static async Task SimpleReadAsync()
        {
            string text = "";
            string filePath = "simple.txt";
            if (File.Exists(filePath) != false)
            {
                text = await File.ReadAllTextAsync(filePath);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine($"file not found: {filePath}");
            }
            
            Console.WriteLine(text);
        }
        static async Task Main(string[] args)
        {
   
            Print();
            await Task.Delay(2000);
            Thread.Sleep(2000);

            string text = Console.ReadLine();
            SimpleWriteAsync(text);
            SimpleReadAsync();
        }
    }
}