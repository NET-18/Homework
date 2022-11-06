namespace HomeWork_09_11_2022;

public class Bike : IMovable
{
    private int _maxSpeed;
    
    public Point Coord { get; set; }
    
    public string Brand { get; set; }

    public int MaxSpeed
    {
        get => this._maxSpeed;
        set
        {
            if (value is < 50 or > 350)
            {
                throw new ArgumentException("It's not a bike or speed too big for this.", nameof(MaxSpeed));
            }

            this._maxSpeed = value;
        }
    }

    public Bike(string brand, int maxSpeed, Point coord)
    {
        Brand = brand;
        MaxSpeed = maxSpeed;
        Coord = coord;
    }
    
    public void Move(double x, double y)
    {
        Coord = new Point(x, y);
    }
}