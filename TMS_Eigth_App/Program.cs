using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text;

namespace TMS_Eigth_App
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            PrintOn();
            await Task.Delay(2000);
            Thread.Sleep(2000);


            await WriteToFileAsync();
            await ProcessReadAsync();

            Console.ReadLine();
        }

        static async Task PrintOn()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Console.Write(i + " ");
            }
        }

        public static async Task WriteToFileAsync()
        {
            string filePath = "temp.txt";
            string text = Console.ReadLine();
            
            await WriteTextAsync(filePath, text);
        }

        async static Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }

        public static async Task ProcessReadAsync()
        {
            try
            {
                string filePath = "temp.txt";
                if (File.Exists(filePath) != false)
                {
                    string text = await ReadTextAsync(filePath);
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine($"file not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async static Task<string> ReadTextAsync(string filePath)
        {
            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true);

            var sb = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
    }
}