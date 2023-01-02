using Generate.Services;

namespace Generate;

public class Friend
{
    public int Id { get; }
    public string Name { get; }

    public Friend(int id)
    {
        Id = id;
        Name = NamesAndSurnamesService.GetName();
    }
}