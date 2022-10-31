namespace ConsoleApp6
{
    class Person
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }
    class Student
    {
        public int Сourse { get; set; }
        public string Department { get; set; }
        public int Progress { get; set; }
        public Person newPerson { get; set; }

        public Student()
        {
            newPerson = new Person();
        }

    }
    class Employee
    {
        public Double Salary { get; set; }
        public int Experience { get; set; }
        public string Position { get; set; }
        public Person newPerson { get; set; }

        public Employee()
        {
            newPerson = new Person();
        }
    }
    internal class Program
    {
        public static void InfoPerson(Person person)
        {
            Console.WriteLine($"Человек {person.Name} {person.Surname}, {person.Gender} в возрасте {person.Age}");
        }
        public static void InfoStudent(Student student)
        {
            if (student.Department == null)
            {
                Console.WriteLine($"Студент отчислен");
            }
            else
                Console.WriteLine($"Студент {student.newPerson.Name} {student.newPerson.Surname}, {student.newPerson.Gender}, Учится на {student.Сourse} курсе на кафедре {student.Department}, Успеваемость на уровне {student.Progress} баллов из 10");
        }

        public static void InfoEmloyee(Employee? employee)
        {
            if (employee.Position == null)
            {
                Console.WriteLine($"Сотрудник уволен");
            }
            else
            Console.WriteLine($"Сотрудник {employee.newPerson.Name} {employee.newPerson.Surname}, {employee.newPerson.Gender}, работает в должности {employee.Position}. Опыт работы {employee.Experience} лет, заработная плата в месяц - {employee.Salary} долл США");
        }
        public static void DeleteEmployee(Employee? employee)
        {
            employee.Salary = -1;
            employee.Experience = -1;
            employee.Position = null;
            employee = null;
            GC.Collect();
        }
        public static void DeleteStudent(Student? student)

        {
            student.Department = null;
            student.Сourse = -1;
            student.Progress = -1;
            student = null;
            GC.Collect();
        }
        public static void LevelUp(Employee employee, double a)
        {
            employee.Salary = employee.Salary + a/100* employee.Salary;
        }
        static void Main(string[] args)
        {
            Person Nikita = new Person()
            {
                Name = "Никита",
                Gender = "Мужчина",
                Surname = "Горндонов",
                Age = 18
            };
            Student NikitaStudent = new Student()
            {
                Сourse = 1,
                Department = "Управление процессами перевозок",
                Progress = 5
            };
            NikitaStudent.newPerson = Nikita;
            Employee Nikitaemployee = new Employee()
            {
                Position = "Официант",
                Experience = 5,
                Salary = 500
            };
            Nikitaemployee.newPerson = Nikita;
           
            Console.WriteLine(Nikitaemployee.Salary);
            LevelUp(Nikitaemployee, 55.5);
            Console.WriteLine(Nikitaemployee.Salary);

            InfoPerson(Nikita);
            InfoEmloyee(Nikitaemployee);
            InfoStudent(NikitaStudent);

            DeleteEmployee(Nikitaemployee);
            DeleteStudent(NikitaStudent);

            InfoEmloyee(Nikitaemployee);
            InfoStudent(NikitaStudent);
            Console.WriteLine(Nikitaemployee.newPerson.Age);

        }
    }
}