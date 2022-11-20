namespace homework_16._11._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = WeaponFactory.Create<PistolMakarov>();
            var k1 = WeaponFactory.Create <AK47>();

            p1.Info();
            k1.Info();

            p1.Loading(6);
            k1.Loading(30);

            p1.Info();
            k1.Info();

            p1.Info();
            p1.Fire(40);
            p1.Info();

            k1.Info();
            k1.Fire(40);
            k1.Info();
        }
    }
}