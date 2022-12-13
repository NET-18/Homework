namespace TNM_Eleventh_App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var start = DateTime.Now;

            string path = "note1.txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync(MyTask());
            }

            var period = DateTime.Now - start;

            Console.WriteLine(period);
        }

        public static string RandomString(int length, out string str)
        {
            Random rand = new Random();

            char[] a = new char[length];

            for (int i = 0; i < length; i++)
            {
                a[i] = (char)rand.Next(0x0041, 0x007A);
            }

            str = new string(a);

            return str;
        }

        public static string MyTask()
        {
            List<string> list = new List<string>();

            string str;

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    RandomString(1000, out str);
                    list.Add(str);
                }
            });
            task.Wait();

            return string.Join("\n", list);
        }
    }
}