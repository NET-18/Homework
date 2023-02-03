namespace ApiWebEF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // это вызовет циклическую зависимость и сериализация сломается
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        // это вызовет циклическую зависимость и сериализация сломается
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
