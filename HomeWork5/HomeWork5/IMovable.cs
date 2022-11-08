namespace HomeWork5
{
    public interface IMovable
    { 
        Point Point { get; set; }
        void Move(Point newLocation);
    }
}