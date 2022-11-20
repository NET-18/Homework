namespace homework_16._11._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new PistolMakarov();
            var k = new AK47();
            WeaponFactory.Create(p);
            WeaponFactory.Create(k);
        }
    }
}