namespace ApiWithEF.Dtos
{
    public class AddOrderDto
    {
        public int UserId { get; set; }
        public List<int> productIds { get; set; }
    }
}
