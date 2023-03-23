using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWithEF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        // это вызовет циклическую зависимость и сериализация сломается
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Product> Products { get; set; }

        // это вызовет циклическую зависимость и сериализация сломается
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
