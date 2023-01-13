using Newtonsoft.Json;

namespace WebApplication3
{
    public class Person
    {
       public  Person()
       {
           
       }
        
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public List<string> Tags { get; set; }
        public List<Friend> Friends { get; set; }

    }
}
