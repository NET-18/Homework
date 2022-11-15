namespace HomeWorkGenericsEasy;

public static class WeaponFactory
{
    public static void Create<T>(T weapon, string name, int yearOfRelease) 
        where T : Weapon
    {
        weapon.Name = name;
        weapon.YearOfRelease = yearOfRelease;
    }

    public static void MakeShoot<T>(T weapon) where T : Weapon
    {
        weapon.Shoot();
    }
}