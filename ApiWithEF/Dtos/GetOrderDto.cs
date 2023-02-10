using ApiWithEF.Models;

namespace ApiWithEF.Dtos;

public class GetOrderDto
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Product> Products { get; set; }
}