using System;
using System.Net;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        public static async Task SimpleWriteAsync(List<Task<string>> tasks)
        {
            Console.WriteLine("SimpleWriteAsync Start");
            int j = 1;
            
            foreach (var item in tasks)
            {
                await File.WriteAllTextAsync($"RandomSites{j++}.txt", item.Result);
            }
            
            Console.WriteLine("SimpleWriteAsync End");
        }
        
        public static async Task<string> DownloadWebsite(string websiteURL, int j)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(websiteURL).Result;
            HttpContent content = response.Content;
            output.Url = websiteURL;
            output.Data = content.ReadAsStringAsync().Result;
            Console.WriteLine(j);
            await Task.Delay(1000);
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
                "https://www.cdprojektred.com",
                "https://yandex.by"
            };
            
            for (int i = 0; i < sites.Length-1; i++)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(sites[i],j++)));
            }

            Task.WhenAll(tasks).Wait();
            SimpleWriteAsync(tasks).Wait();
            Console.ReadLine();


        }
    }
}