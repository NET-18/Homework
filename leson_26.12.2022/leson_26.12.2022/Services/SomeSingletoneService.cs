namespace leson_26._12._2022.Services
{
    public class SomeSingletoneService : IDisposable
    {
        public SomeSingletoneService()
        {
            Console.WriteLine("singleton: ya sozdalsya =)");
        }

        public void Dispose()
        {
            Console.WriteLine("singletone: Ya sdoh =(");
        }
    }
}
