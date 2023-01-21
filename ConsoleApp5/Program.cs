namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balanceInt = 999;
            string balance = "";
            if (balanceInt > 999_999)
            {
                int balance1part = balanceInt / 1000000;
                int balance2part = balanceInt / 1000 - balance1part * 1000;
                int balance3part = balanceInt - balance2part * 1000 - balance1part * 1000000;
                balance = $"{balance1part},{balance2part}.{balance3part}";
            }
            if (balanceInt >= 999 && balanceInt <= 999_999)
            {
                int balance2part = balanceInt / 1000;
                int balance3part = balanceInt - balance2part * 1000;
                balance = $"{balance2part}.{balance3part}";
            }
            if (balanceInt < 999)
            {
                balance = $"0.{balanceInt}";
            }

                Console.WriteLine(balance);
            Console.WriteLine(balanceInt);
        }
    }
}