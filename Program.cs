namespace homework_16._11._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = WeaponFactory.Create<PistolMakarov>(8);
            var k1 = WeaponFactory.Create <AK47>(30);

            p1.Info();
            k1.Info();

            p1.Loading(6);
            k1.Loading(35);

            p1.Info();
            k1.Info();

            p1.Info();
            p1.Fire(40);
            p1.Info();

            k1.Info();
            k1.Fire(40);
            k1.Info();

            var p2 = ObjectFactory.Create<PistolMakarov>();
            p2.Info();

            var k2 = ObjectFactory.Create<AK47>();
            k2.Info();
        }
    }
}