namespace HomeWork_09_11_2022;

public class Person : IMovable
{
    private int _age;
    
    public Point Coord { get; set; }
    public string Name { get; set; }
    public int Age
    {
        get => this._age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be less than zero.", nameof(Age));
            }

            this._age = value;
        }
    }

    public Person(string name, int age, Point coord)
    {
        Name = name;
        Age = age;
        Coord = coord;
    }
    
    public void Move(double x, double y)
    {
        Coord = new Point(x, y);
    }
}