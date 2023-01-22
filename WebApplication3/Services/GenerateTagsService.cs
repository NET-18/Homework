namespace WebApplication3.Services
{
    public class GenerateTagsService
    {
        public async Task<List<string>> GetRandomTags(int tags)
        {
            string[] valueTags = { "occaecat", "adipisicing", "mollit", "cillum", "qui", "ullamco", "fugiat", "reprehenderit", "consequat", "nisi" };
            var listTags = new List<string>();
            for (int i = 0; i < tags; i++)
            {
                listTags.Add(valueTags[Random.Shared.Next(0, valueTags.Length)]);
            }
            return listTags;
        }
    }
}
