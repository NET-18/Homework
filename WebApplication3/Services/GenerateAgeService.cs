namespace WebApplication3.Services
{
    public class GenerateAgeService
    {
        public async Task<int> GetRandomAge()
        {
            var Age = Random.Shared.Next(0, 100);
            return Age;
        }
    }
}
