namespace HomeWork_09_11_2022;

public class Car : IMovable
{
    private int _maxSpeed;
    private int _countOfShift;
    
    public Point Coord { get; set; }
    
    public string Brand { get; set; }

    public int MaxSpeed
    {
        get => this._maxSpeed;
        set
        {
            if (value is < 0 or > 1230)
            {
                throw new ArgumentException("Speed cannot be less than zero or it's too big for car", nameof(MaxSpeed));
            }

            this._maxSpeed = value;
        }
    }

    public int CountOfShift
    {
        get => this._countOfShift;
        set
        {
            if (value is < 0 or > 7)
            {
                throw new ArgumentException("Wrong count of shift.", nameof(CountOfShift));
            }

            this._countOfShift = value;
        }
    }

    public Car(string brand, int maxSpeed, int countOfShift, Point coord)
    {
        Brand = brand;
        MaxSpeed = maxSpeed;
        CountOfShift = countOfShift;
        Coord = coord;
    }
    
    public void Move(double x, double y)
    {
        Coord = new Point(x, y);
    }
}