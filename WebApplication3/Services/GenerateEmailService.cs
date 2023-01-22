namespace WebApplication3.Services
{
    public class GenerateEmailService
    {
        public async Task<string> GetRandomEmail()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var email = "";

            for (int i = 0; i < Random.Shared.Next(0, 15); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += "@";
            for (int i = 0; i < Random.Shared.Next(0, 10); i++)
            {
                email = email + chars[Random.Shared.Next(0, chars.Length)];
            }
            email += ".com";

            return email;
        }

    }
}
