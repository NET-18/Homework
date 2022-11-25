using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    enum TypeSchool
    {
        ElementarySchool,
        JuniorHighSchool,
        HighSchool,
        Unknown
    }
    public class School : EducationalEstablishment
    {
        public int PregnantEnglishTeachersCount { get; set; }

        public override void Info()
        {
            String text = "Type of educational establishment: SCHOOL\n" +
                         $"Name: {Name}\n" +
                         $"Adress: {Address}" + 
                         $"Workers number: {WorkersNumber}\n" +
                         $"Student number: {StudentNumber}\n" +
                         $"Number of english teachers who are pregnant: {PregnantEnglishTeachersCount}\n";
            Console.WriteLine(text);
        }
    }
}
