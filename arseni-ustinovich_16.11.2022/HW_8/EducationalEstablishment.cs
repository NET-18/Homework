using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    public abstract class EducationalEstablishment
    {
        public string? Name { get; set; }
        public int WorkersNumber { get; set; }
        public int StudentNumber { get; set; }
        public string? Address { get; set; }
        public abstract void Info();
    }
}
