namespace HomeWorkGenericsEasy;

public class Machine : Weapon
{
    public override string Name { get; set; }
    public override int YearOfRelease { get; set; }
    public override void Shoot()
    {
        Console.WriteLine("Piu piu piu");
    }
}