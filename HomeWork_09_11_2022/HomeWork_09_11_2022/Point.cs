namespace HomeWork_09_11_2022;

public struct Point
{
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }

    public double Y { get; }

    public override string ToString() => $"X: {X} \nY: {Y}";

    public override bool Equals(object? obj)
    {
        if (obj is not Point point)
        {
            return false;
        }

        return (point.X == this.X) && (point.Y == this.Y);
    }
}