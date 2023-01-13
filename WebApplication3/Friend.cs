namespace WebApplication3
{
    public class Friend
    {
        public Friend()
        {
        }

        public Friend(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
