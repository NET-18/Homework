using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozyrev_19._12._2022
{
    internal class Person
    {
        [JsonProperty("_id")]
        public string ID { get; set; }
        public string Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balanse { get; set; } 
        public int Age { get; set; }    
        public string Name { get; set; }
        public string gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string[] Tags { get; set; }
        public List<Friend> Friends { get; set; }


    }
}
