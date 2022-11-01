namespace TMS_Fourth_App
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

    }
    class Studen : Person
    {
        public string Course { get; set; }
        public string Department { get; set; }
        public Person Person { get; set; }
    }
    class Employee : Person
    {
        public int SalaryInHour { get; set; }
        public int SalaryInMonth { get; set; }
        public int Experience { get; set; }
        public Person Person { get; set; }
    }


    internal class Program
    {
        static void InfAbHum(Person person)
        {
            Console.WriteLine($"Имя: {person.Name} Фамилия: {person.SurName} Возраст: {person.Age}");
        }
        static void InfAbStud(Studen studen)
        {
            Console.WriteLine($"Имя: {studen.Name} Фамилия: {studen.SurName} Возраст: {studen.Age} Курс: {studen.Course} Кафедра: {studen.Department}");
        }
        static void InfAbEmp(Employee employee)
        {
            Console.WriteLine($"Имя: {employee.Name} Фамилия: {employee.SurName} Возраст: {employee.Age} Зарплата в час: {employee.SalaryInHour} Зарплата в месяц: {employee.SalaryInMonth} Стаж: {employee.Experience}");
        }
        static void SalaryUp(Employee employee, int salaryUpProcent)
        {
            Console.WriteLine($"увеличенная зп: {employee.SalaryInMonth * (1 + salaryUpProcent / 100.0)}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Возраст, Имя, Фамилия");
            Person person = new Person()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine()
            };
            Console.WriteLine("Возраст, Имя, Фамилия, Курс, Факультет");
            Studen student = new Studen()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine(),
                Course = Console.ReadLine(),
                Department = Console.ReadLine()

            };
            Console.WriteLine("Возраст, Имя, Фамилия, ЗП в час, ЗП в месяц, Опыт");
            Employee employee = new Employee()
            {
                Age = int.Parse(Console.ReadLine()),
                Name = Console.ReadLine(),
                SurName = Console.ReadLine(),
                SalaryInHour = int.Parse(Console.ReadLine()),
                SalaryInMonth = int.Parse(Console.ReadLine()),
                Experience = int.Parse(Console.ReadLine())
            };
            InfAbHum(person);
            InfAbStud(student);
            InfAbEmp(employee);
            Console.WriteLine("Процент для увеличения ЗП: ");
            SalaryUp(employee, int.Parse(Console.ReadLine()));
            Console.WriteLine();
        }
    }
}