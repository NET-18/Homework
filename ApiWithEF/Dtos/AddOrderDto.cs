namespace ApiWithEF.Dtos;

public class AddOrderDto
{
    public int UserId { get; set; }
    public int[] ProductsId { get; set; }
}