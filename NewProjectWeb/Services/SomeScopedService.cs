namespace NewProjectWeb.Services;

public class SomeScopedService
{
    public Guid Id { get; set; }

    public SomeScopedService()
    {
        Id = Guid.NewGuid();
    }
}