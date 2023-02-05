using System.Text.Json.Serialization;
using Generate.Services;
using Newtonsoft.Json;

namespace Generate;

public class Person
{
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

}