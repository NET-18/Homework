namespace HomeWorkGenericsEasy;

public static class WeaponHelper
{
    public static T Create<T>(string name, int yearOfRelease) 
        where T : Weapon, new()
    {
        var result = new T()
        {
            Name = name,
            YearOfRelease = yearOfRelease
        };

        return result;
    }

    public static void MakeShoot<T>(T weapon) where T : Weapon
    {
        weapon.Shoot();
    }
}