namespace WebApplication2.Services
{
    public class SomeSingleToneService: IDisposable
    {
        public SomeSingleToneService()
        { 
            Console.WriteLine("singletone: created");
        }
        public void Dispose()
        {
            Console.WriteLine("singletone: ya sdoh");
        }
    }
}
