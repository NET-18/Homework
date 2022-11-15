namespace HomeWorkGenericsEasy;

public class Gun: Weapon
{
    public override string Name { get; set; }
    public override int YearOfRelease { get; set; }
    public override void Shoot()
    {
        Console.WriteLine("Piu");
    }
}