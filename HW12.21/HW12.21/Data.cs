using Newtonsoft.Json;

namespace HW12._21
{
    public class Data
    {
        public Info Info { get; set; }

        [JsonProperty("results")]
        public List<Character> Characters { get; set; }
    }
}