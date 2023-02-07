using ApiWithEF.Models;

namespace ApiWithEF.Dtos
{
    public class AddOrderDto
    {
        public int UserId { get; set; }

        public ICollection<int> ProductsId { get; set; }

    }
}
