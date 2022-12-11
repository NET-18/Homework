using System.Net;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        public static async Task SimpleWriteAsync(List<Task<string>> tasks)
        {
            Console.WriteLine("SimpleWriteAsync Start");
            string filePath = "RandomSites.txt";
            string text = "";
            foreach (var item in tasks)
            {
                text += item.Result + "\n\n";
            }
            await File.WriteAllTextAsync(filePath, text);
            Console.WriteLine("SimpleWriteAsync End");
        }
        
        public static string DownloadWebsite(string websiteURL, int j)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.Url = websiteURL;
            output.Data = client.DownloadString(websiteURL);
            Console.WriteLine(j);
            return output.Data;
        }
        

        static void Main(string[] args)
        {
            int j = 0;
            
            List<Task<string>> tasks = new List<Task<string>>();

            string[] sites = new string[]
            {
                "https://www.yahoo.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.cnn.com",
                "https://www.codeproject.com",
                "https://www.cdprojektred.com"
            };
            
            for (int i = 0; i < sites.Length-1; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => DownloadWebsite(sites[i],j++)));
            }

            Task.WhenAll(tasks).Wait();
            SimpleWriteAsync(tasks).Wait();
            Console.ReadLine();


        }
    }
}