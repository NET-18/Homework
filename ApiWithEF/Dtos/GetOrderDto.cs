namespace ApiWithEF.Dtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public DateTime SelectTime { get; set; }
    }
}
