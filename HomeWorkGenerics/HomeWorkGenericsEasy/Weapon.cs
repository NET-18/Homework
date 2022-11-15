namespace HomeWorkGenericsEasy;

public abstract class Weapon
{
    public abstract string Name { get; set; }
    public abstract int YearOfRelease { get; set; }
    public abstract void Shoot();

    public void Print()
    {
        Console.WriteLine("Name: {0}\nYear of release: {1}", Name, YearOfRelease);
    }
}