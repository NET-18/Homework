using System.ComponentModel.DataAnnotations;

namespace ApiWebEF.Models
{
    public class User
    {
        public int Id { get; set; }
        //[Key] атрибут
        public string Name { get; set; }
        //[StringLenght(100)] 
        public string Surname { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
