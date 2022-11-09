namespace ConsoleApp1
{

    internal struct Point 
    {
        public int x;
        public int y;
        
        public Point()
        {
            Random rnd = new();
            x = rnd.Next(-500, 500);
            y = rnd.Next(-500, 500);
        } 
    } 


    interface IMovable 
    {
        void Move() { }
        public Point point { get; set; }
    }


    
    static class Program 
    {
        static void Main() 
        {
            IMovable[] objects = new IMovable[3];
            objects[0] = new Person();
            objects[1] = new Bike();
            objects[2] = new Car();
            Distance.GetDistance(objects[0].point.x, objects[0].point.y, objects[1].point.x, objects[1].point.y, objects[2].point.x, objects[2].point.y);

            objects[0].Move();
            objects[1].Move();
            objects[2].Move();
            Distance.GetDistance(objects[0].point.x, objects[0].point.y, objects[1].point.x, objects[1].point.y, objects[2].point.x, objects[2].point.y);
            return;
        }

       
    }
   
}
