namespace Generate.Services;

public class MergingService
{
    private  string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    
    private readonly NamesAndSurnamesService _namesAndSurnamesService;
    private readonly EmailsService _emailsService;
    private readonly FriendsService _friendsService;
    private readonly LargeTextsService _largeTextsService;
    private readonly PhoneNumbersService _phoneNumbersService;
    private readonly WordsService _wordsService;

    MergingService(NamesAndSurnamesService namesAndSurnamesService, EmailsService emailsService,
        FriendsService friendsService, LargeTextsService largeTextsService,
        PhoneNumbersService phoneNumbersService, WordsService wordsService
    )
    {
        _namesAndSurnamesService = namesAndSurnamesService;
        _emailsService = emailsService;
        _friendsService = friendsService;
        _largeTextsService = largeTextsService;
        _phoneNumbersService = phoneNumbersService;
        _wordsService = wordsService;
    }
    
    public async Task<List<Person>> GetRandomCountOFObject()
    {
        var count = Random.Shared.Next(1, 200);
        var list = new List<Person>();
        var name = "";
        for (var i = 0; i < count; i++)
        {
            name = _namesAndSurnamesService.GetName();
            
            list.Add(new Person()
            {
                Id = GenerateId(),
                Guid = Guid.NewGuid(),
                IsActive = Random.Shared.Next(0, 1) != 0,
                Balance = $"${Random.Shared.Next(100000)},{Random.Shared.Next(99)}",
                Age = Random.Shared.Next(22, 120),
                Name = name,
                Gender = Random.Shared.Next(0, 1) == 0 ? "male" : "female",
                Email = _emailsService.GetEmail(name),
                Phone = _phoneNumbersService.GetRandomNumber(),
                Address =
                    $"{Faker.RandomNumber.Next()} {Faker.Address.Country()}, {Faker.Address.City()}, {Faker.Address.StreetName()}, {Faker.RandomNumber.Next()}",
                About = _largeTextsService.GetLargeText(),
                Tags = _wordsService.GetWordsRandom(),
                Friends = _friendsService.GetFriendsRandom().ToArray()
            });
        }

        return list;
    }
    
    public async Task<List<Person>> GetFixCountOFObject(int count, int countOfTags, int countOfFriends)
    {
        var list = new List<Person>();
        var name = "";
        
        for (var i = 0; i < count; i++)
        {
            name = _namesAndSurnamesService.GetName();

            list.Add(new Person()
            {
                Id = GenerateId(),
                Guid = System.Guid.NewGuid(),
                IsActive = Random.Shared.Next(0, 1) != 0,
                Balance = $"${Random.Shared.Next(100000)},{Random.Shared.Next(99)}",
                Age = Random.Shared.Next(22, 120),
                Name = name,
                Gender = Random.Shared.Next(0, 1) == 0 ? "male" : "female",
                Email = _emailsService.GetEmail(name),
                Phone = _phoneNumbersService.GetRandomNumber(),
                Address =
                $"{Faker.RandomNumber.Next()} {Faker.Address.Country()}, {Faker.Address.City()}, {Faker.Address.StreetName()}, {Faker.RandomNumber.Next()}",
                About = _largeTextsService.GetLargeText(),
                Tags = _wordsService.GetWordsCount(countOfTags),
                Friends = _friendsService.GetFriendsCount(countOfFriends).ToArray(),
            });
        }

        return list;
    }
    
    private string GenerateId()
    {
        var stringChars = new char[24];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        
        return new String(stringChars);
    }
}