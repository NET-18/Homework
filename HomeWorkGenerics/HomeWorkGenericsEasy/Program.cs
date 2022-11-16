namespace HomeWorkGenericsEasy
{
    class Program
    {
        public static void Main(string[] args)
        {
            var gun = WeaponHelper.Create<Gun>("PM", 1945);
            var bazooka = WeaponHelper.Create<Bazooka>("M1", 1942);
            var machine  = WeaponHelper.Create<Machine>("AK-47", 1947);
            var machineGun = WeaponHelper.Create<MachineGun>("Czechoslovak", 1959);
            
            gun.Print();
            Console.WriteLine();
            
            bazooka.Print();
            Console.WriteLine();
            
            machine.Print();
            Console.WriteLine();
            
            machineGun.Print();
            Console.WriteLine();

            Console.Write("{0} makes shoot: ", gun.Name);
            WeaponHelper.MakeShoot(gun);
            
            Console.Write("{0} makes shoot: ", bazooka.Name);
            WeaponHelper.MakeShoot(bazooka);
            
            Console.Write("{0} makes shoot: ", machine.Name);
            WeaponHelper.MakeShoot(machine);
            
            Console.Write("{0} makes shoot: ", machineGun.Name);
            WeaponHelper.MakeShoot(machineGun);
        }
    }
}
