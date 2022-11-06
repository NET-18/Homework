namespace HomeWork_09_11_2022;

public struct Point
{
    private double x;
    private double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double GetX() => this.x;

    public double GetY() => this.y;

    public override string ToString() => $"X: {this.x} \nY: {this.y}";

    public override bool Equals(object? obj)
    {
        if (obj is not Point point)
        {
            return false;
        }

        return (point.x == this.x) && (point.y == this.y);
    }
}