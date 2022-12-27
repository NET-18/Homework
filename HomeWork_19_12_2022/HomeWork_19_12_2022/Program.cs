using HomeWork_19_12_2022;
using Newtonsoft.Json;

class Program
{
    public static async Task Main(string[] args)
    {
        var json = await File.ReadAllTextAsync("generated.json");
        var list = JsonConvert.DeserializeObject<List<JsonHelper>>(json);
        var newList = list.OrderBy(x => x.Age).Where(x => x.Friends.Length > 3);

        var serialize = JsonConvert.SerializeObject(newList);
        await File.WriteAllTextAsync("sorted.json", serialize);
    }
}