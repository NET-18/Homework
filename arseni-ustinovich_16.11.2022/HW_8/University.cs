using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    public class University : EducationalEstablishment
    {
        public int CountOfFaculty { get; set; } = -1;
        public int CountOfDorms { get; set; } = -1;

        public override void Info()
        {
            String text = "Type of educational establishment: UNIVERSITY\n" +
                         $"Name: {Name}\n" +
                         $"Adress: {Address}" +
                         $"Workers number: {WorkersNumber}\n" +
                         $"Student number: {StudentNumber}\n" +
                         $"Faculties count: {CountOfFaculty}\n" +
                         $"Dorms count: {CountOfDorms}\n";
            Console.WriteLine(text);
        }
    }
}
