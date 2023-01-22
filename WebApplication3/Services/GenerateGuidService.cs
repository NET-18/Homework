namespace WebApplication3.Services
{
    public class GenerateGuidService
    {
        public async Task<Guid> GetRandomGuid()
        {
            var guid = Guid.NewGuid();
            return guid;
        }

    }
}
