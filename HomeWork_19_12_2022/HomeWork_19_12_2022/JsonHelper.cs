using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HomeWork_19_12_2022;

public class JsonHelper
{
    [JsonProperty("_id")]
    public string Id { get; set; }
    
    public string Guid { get; set; }
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
}