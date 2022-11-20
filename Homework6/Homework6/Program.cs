 namespace Homework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var blush = new Blush();
            var lipstick = new Lipstick();
            var mascara = new Mascara();

            MakeUpFactory.Create(blush);
            MakeUpFactory.Create(lipstick);
            MakeUpFactory.Create(mascara);
        }
    }
}