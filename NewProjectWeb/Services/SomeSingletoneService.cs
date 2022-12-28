namespace NewProjectWeb.Services;

public class SomeSingletoneService : IDisposable
{
    public SomeSingletoneService()
    {
        Console.WriteLine("singletone: Jopa :) ");
    }

    public void Dispose()
    {
        Console.WriteLine("singletone: Smert' :( ");
    }
}