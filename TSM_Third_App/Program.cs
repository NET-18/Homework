using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TSM_Third_App
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

    }
    class Studen
    {
        public string Course { get; set; }
        public string Department { get;set; }
    }
    class Employee
    {
        public int SalaryInHour { get; set; }
        public int SalaryInMonth { get; set;  }
        public int Experience { get; set; }
    }


    internal class Program
    {
        static void InfAbHum(Person person)
        {
            Console.WriteLine($"Имя: {person.Name} Фамилия: {person.SurName} Возраст: {person.Age}");
        }
        static void InfAbStud(Person person, Studen studen)
        {
            Console.WriteLine($"Имя: {person.Name} Фамилия: {person.SurName} Возраст: {person.Age} Курс: {studen.Course} Кафедра: {studen.Department}");
        }
        static void InfAbEmp(Person person, Employee employee)
        {
            Console.WriteLine($"Имя: {person.Name} Фамилия: {person.SurName} Возраст: {person.Age} Зарплата в час: {employee.SalaryInHour} Зарплата в месяц: {employee.SalaryInMonth} Стаж: {employee.Experience}");
        }
        static void SalaryUp(Employee employee, int salaryUpProcent)
        {
            Console.WriteLine($"увеличенная зп: {employee.SalaryInMonth * (1 + salaryUpProcent / 100.0)}");
        }
        static void DeleteStud(Person person, Studen student)
        {
            person = null;
            student = null;
        }
        static void DeleteEmp(Person person, Employee employee)
        {
            person = null;
            employee = null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Возраст, Имя, Фамилия");
            Person person0 = new Person()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine()
            };
            Console.WriteLine("Возраст, Имя, Фамилия, Курс, Факультет");
            Person person1 = new Person()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine()
            };
            Studen student = new Studen()
            {
                Course = Console.ReadLine(),
                Department = Console.ReadLine()

            };
            Console.WriteLine("Возраст, Имя, Фамилия, ЗП в час, ЗП в месяц, Опыт");
            Person person2 = new Person()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine()
            };
            Employee employee = new Employee()
            {
                SalaryInHour = int.Parse(Console.ReadLine()),
                SalaryInMonth = int.Parse(Console.ReadLine()),
                Experience = int.Parse(Console.ReadLine())
            };
            InfAbHum(person0);
            InfAbStud(person1, student);
            InfAbEmp(person2, employee);
            Console.WriteLine("Процент для увеличения ЗП: ");
            SalaryUp(employee, int.Parse(Console.ReadLine()));
            Console.WriteLine();
            DeleteStud(person1, student);
            DeleteEmp(person2,employee);
        }
    }
}