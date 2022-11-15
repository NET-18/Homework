namespace HomeWorkGenericsEasy
{
    class Program
    {
        public static void Main(string[] args)
        {
            var gun = new Gun();
            var bazooka = new Bazooka();
            var machine = new Machine();
            var machineGun = new MachineGun();
            
            WeaponFactory.Create(gun, "PM", 1945);
            WeaponFactory.Create(bazooka, "M1", 1942);
            WeaponFactory.Create(machine, "AK-47", 1947);
            WeaponFactory.Create(machineGun, "Czechoslovak", 1959);
            
            gun.Print();
            Console.WriteLine();
            
            bazooka.Print();
            Console.WriteLine();
            
            machine.Print();
            Console.WriteLine();
            
            machineGun.Print();
            Console.WriteLine();

            Console.Write("{0} makes shoot: ", gun.Name);
            WeaponFactory.MakeShoot(gun);
            
            Console.Write("{0} makes shoot: ", bazooka.Name);
            WeaponFactory.MakeShoot(bazooka);
            
            Console.Write("{0} makes shoot: ", machine.Name);
            WeaponFactory.MakeShoot(machine);
            
            Console.Write("{0} makes shoot: ", machineGun.Name);
            WeaponFactory.MakeShoot(machineGun);
        }
    }
}
