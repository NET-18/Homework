namespace Generate.Services;

public static class MergingService
{
    public static async Task<List<Person>> GetRandomCountOFObject()
    {
        int count = Random.Shared.Next(1, 200);
        List<Person> list = new List<Person>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new Person());
        }

        return list;
    }
    
    public static async Task<List<Person>> GetFixCountOFObject(int count, int countOfTags, int countOfFriends)
    {
        List<Person> list = new List<Person>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new Person(countOfTags, countOfFriends));
        }

        return list;
    }
}