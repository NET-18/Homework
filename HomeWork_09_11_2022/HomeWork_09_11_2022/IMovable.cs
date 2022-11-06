namespace HomeWork_09_11_2022;

public interface IMovable
{
    Point Coord { get; set; }
    void Move(double x, double y);
}