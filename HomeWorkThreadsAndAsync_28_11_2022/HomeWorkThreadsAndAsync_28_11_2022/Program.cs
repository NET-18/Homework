using System.Text;

namespace HomeWorkThreadsAndAsync_28_11_2022
{
     class Program
     {
          public static async Task Main(string[] args)
          {
               // PrintSmth();
               // await Task.Delay(2000);
               // Thread.Sleep(2000);

               await ProcessWriteAsync();
               await ProcessReadAsync();
          }

          private static async Task PrintSmth()
          {
               for (var i = 0; i < 10; i++)
               {
                    await Task.Delay(500);
                    Console.WriteLine("Print #{0}", i + 1);
               }
          }
          
          private static async Task ProcessWriteAsync()
          {
               var filePath = "temp.txt";
               Console.Write("Enter text: ");
               var text = Console.ReadLine() ?? "Invalid text.";

               await WriteTextAsync(filePath, text);
          }

          private static async Task WriteTextAsync(string filePath, string text)
          {
               byte[] encodedText = Encoding.Unicode.GetBytes(text);

               using var sourceStream =
                    new FileStream(
                         filePath,
                         FileMode.Create, FileAccess.Write, FileShare.None,
                         bufferSize: 4096, useAsync: true);

               await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
          }
          
          private static async Task ProcessReadAsync()
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

          private static async Task<string> ReadTextAsync(string filePath)
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
