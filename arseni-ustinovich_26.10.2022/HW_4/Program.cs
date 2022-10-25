namespace HW_4
{  
   
    internal class Program
    {
        public struct XYZ
        {
            public double _x;
            public double _y;
            public double _z;

            public XYZ(double x, double y, double z)
            {
                this._x = x;
                this._y = y;
                this._z = z;
            }

        }
        
        static double distance(XYZ a, XYZ b) => Math.Sqrt(Math.Pow(a._x - b._x, 2) + Math.Pow(a._y - b._y, 2) + Math.Pow(a._z - b._z, 2));
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A coordinates:");
            XYZ A = new XYZ(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("Enter B coordinates:");
            XYZ B = new XYZ(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("Distannce between A and B is {0:f4}", distance(A, B));
        }
    }
}