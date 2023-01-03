namespace WebApplication2.Services
{
    public class SomeScopedService
    {
        public Guid Id { get; set; }

        public SomeScopedService()
        {
            Id= Guid.NewGuid();
        }
    }
}
