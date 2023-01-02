using System.Text.Json.Serialization;
using Generate.Services;
using Newtonsoft.Json;

namespace Generate;

public class Person
{
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    [JsonProperty("_id")]
    public string Id { get; set; }
    
    public Guid Guid { get; set; }
    public bool IsActive { get; set; }
    public string Balance { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string About { get; set; }
    public string[] Tags { get; set; }
    public Friend[] Friends { get; set; }

    public Person()
    {
        Id = GenerateId();
        Guid = System.Guid.NewGuid();
        IsActive = Random.Shared.Next(0, 1) != 0;
        Balance = $"${Random.Shared.Next(100000)},{Random.Shared.Next(99)}";
        Age = Random.Shared.Next(22, 120);
        Name = NamesAndSurnamesService.GetName();
        Gender = Random.Shared.Next(0, 1) == 0 ? "male" : "female";
        Email = EmailsService.GetEmail(Name);
        Phone = PhoneNumbersService.GetRandomNumber();
        Address =
            $"{Faker.RandomNumber.Next()} {Faker.Address.Country()}, {Faker.Address.City()}, {Faker.Address.StreetName()}, {Faker.RandomNumber.Next()}";
        About = LargeTextsService.GetLargeText();
        Tags = WordsService.GetWordsRandom();
        Friends = FriendsService.GetFriendsRandom().ToArray();
    }
    
    public Person(int countOfTags, int countOfFriends)
    {
        Id = GenerateId();
        Guid = System.Guid.NewGuid();
        IsActive = Random.Shared.Next(0, 1) != 0;
        Balance = $"${Random.Shared.Next(100000)},{Random.Shared.Next(99)}";
        Age = Random.Shared.Next(22, 120);
        Name = NamesAndSurnamesService.GetName();
        Gender = Random.Shared.Next(0, 1) == 0 ? "male" : "female";
        Email = EmailsService.GetEmail(Name);
        Phone = PhoneNumbersService.GetRandomNumber();
        Address =
            $"{Faker.RandomNumber.Next()} {Faker.Address.Country()}, {Faker.Address.City()}, {Faker.Address.StreetName()}, {Faker.RandomNumber.Next()}";
        About = LargeTextsService.GetLargeText();
        Tags = WordsService.GetWordsCount(countOfTags);
        Friends = FriendsService.GetFriendsCount(countOfFriends).ToArray();
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