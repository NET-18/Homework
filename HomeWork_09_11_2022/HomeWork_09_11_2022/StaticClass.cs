namespace HomeWork_09_11_2022;

public static class IMovableHelper
{
    public static double Distance(IMovable first, IMovable second) =>
        Math.Sqrt(Math.Pow(first.Coord.X - second.Coord.X, 2) +
                  Math.Pow(first.Coord.Y - second.Coord.Y, 2));
}