namespace WebApplication3.Services
{
    public class GenerateFriendService
    {
        private readonly GeneratePersonNameService _personNameService;

        public GenerateFriendService(GeneratePersonNameService personNameService)
        {
            _personNameService = personNameService;
        }

        public async Task<List<Friend>> GetRandomFriends(int friends)
        {
            var listFriends = new List<Friend>();
            for (int i = 0; i < friends; i++)
            {
                var person = await _personNameService.GetRandomPersonName();
                listFriends.Add(new Friend()
                {
                    Id = i,
                    Name = person.Name
                });
            }
            return listFriends;
        }
    }
}
