namespace Generate.Services;

public class FriendsService
{
    public List<Friend> GetFriendsRandom()
    {
        var friends = new List<Friend>();

        for (int i = 0; i < Random.Shared.Next(1, 10); i++)
        {
            friends.Add(new Friend(i + 1));
        }
        
        return friends;
    }
    
    public List<Friend> GetFriendsCount(int count)
    {
        var friends = new List<Friend>();

        for (int i = 0; i < count; i++)
        {
            friends.Add(new Friend(i + 1));
        }
        
        return friends;
    }
}