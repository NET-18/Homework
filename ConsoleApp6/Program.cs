namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var email = "";

            for (int i = 0; i < Random.Shared.Next(0, 15); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += "@";
            for (int i = 0; i < Random.Shared.Next(0, 10); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += ".com";
            Console.WriteLine( email);
        }
    }
}