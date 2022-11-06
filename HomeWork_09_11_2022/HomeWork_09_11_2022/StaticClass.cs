namespace HomeWork_09_11_2022;

public static class StaticClass
{
    public static double DistanceBetweenIMovable(IMovable first, IMovable second) =>
        Math.Sqrt(Math.Pow(first.Coord.GetX() - second.Coord.GetX(), 2) +
                  Math.Pow(first.Coord.GetY() - second.Coord.GetY(), 2));
}