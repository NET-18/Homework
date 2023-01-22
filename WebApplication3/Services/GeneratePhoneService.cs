namespace WebApplication3.Services
{
    public class GeneratePhoneService
    {
        public async Task<string> GetRandomPhone()
        {
            int part1 = Random.Shared.Next(0, 7);
            int part2 = Random.Shared.Next(99, 999);
            int part3 = Random.Shared.Next(99, 999);
            int part4 = Random.Shared.Next(999, 9999);

            var phone = $"+{part1} ({part2}) {part3}-{part4}";
            return phone;
        }
    }
}
