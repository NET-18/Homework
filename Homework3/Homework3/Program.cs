using System.ComponentModel.DataAnnotations;

namespace Homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("nik", 15, "lish");
            var student = new Student("vlad", 16, "begl", 4, "hfg");
            var eployee = new Eployee(100, 200, 300, "Nikita", 20, "Lis");
            //.AddSalary(100);
            //eployee.DeleteEployee(eployee);
            //.DeleteStudent(student);
            Person Nik = new Person("Nikita", 18 ,"Lish");
            Nik.print();
            eployee.print();

            
        }
    }
}
   
   
