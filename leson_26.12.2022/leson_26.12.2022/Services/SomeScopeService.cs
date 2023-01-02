namespace leson_26._12._2022.Services
{
    public class SomeScopedService
    {
        public Guid Id { get; set; }

        public SomeScopedService()
        {
            Id = Guid.NewGuid();
        }
    }
}
