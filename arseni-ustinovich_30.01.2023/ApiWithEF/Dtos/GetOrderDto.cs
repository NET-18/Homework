using System.Runtime.CompilerServices;

namespace ApiWithEF.Dtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<NamedTuple> Products { get; set; }
        public int UserId { get; set; }

        public class NamedTuple
        {
            public NamedTuple(int id, string name, int count)
            {
                Id = id;
                Name = name;
                Count = count;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
        }

    }
   
}
