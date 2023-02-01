using System.IO;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TMS_DZAsyncSerializeLession_14_12_2022
{
    public class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            var webSites = new List<string>
            {
                "https://www.google.com/",
                "https://www.youtube.com/",
                "https://www.microsoft.com/",
                "https://www.java.com/",
                "https://www.python.org/"
            };

            var arrTask = new Task[webSites.Count];

            for (int i = 0;i < webSites.Count; i++)
            {
                int localI = i;
                arrTask[localI] = Task.Factory.StartNew(() =>
                {
                    File.WriteAllText($"siteHtml{localI}.txt", code(webSites[localI]));
                });
            }
            Task.WhenAll(arrTask).Wait();

            var period = DateTime.Now - start;
            Console.WriteLine(period);
        }
        public static void writeText(string link)
        {
            File.AppendAllText("htmlSite.txt", code(link));
        }

        public static String code(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Timeout = 300000;
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }
    }
}