namespace HomeWork15_11_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sam = new Sam()
            {
                MaxSpeed = 20,
                MinSpeed = 1
            };
            var tom = new Tom()
            {
                MaxSpeed = 20,
                MinSpeed = 1
            };
            PersonFactory.Procces(tom);
            PersonFactory.Procces(sam);
            var clonedtom = PersonFactory.Clone(tom);
            var clonedsam = PersonFactory.Clone(sam);      
        }
    }
}