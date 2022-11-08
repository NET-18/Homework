namespace ConsoleApp6
{
    public class Person
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual void Print(Person person)
        {
            Console.WriteLine($"Человек {person.Name} {person.Surname}, {person.Gender} в возрасте {person.Age}");
        }

        public virtual void Base()
        {
            Console.WriteLine("Это БАЗОВЫЙ МЕТОД НИКИТЫ!!!");
        }
    }

    public class Student : Person
    {
        public int Сourse { get; set; }
        public string Department { get; set; }
        public int Progress { get; set; }
        public override void Base()
        {
            Console.WriteLine("Это СТУДЕНТЕЧЕСКИЙ МЕТОД НИКИТЫ!!!");
        }
    }

    public class Employee : Person
    {
        public Double Salary { get; set; }
        public int Experience { get; set; }
        public string Position { get; set; }

        public override void Base()
        {
            Console.WriteLine("Это РАБОЧИЙ МЕТОД НИКИТЫ!!!");
        }
    }

    internal class Program
    {
        public static void PrintStudent(Student? student)
        {
            if (student.Department == null)
            {
                Console.WriteLine($"Студент отчислен");
            }
            else
            {
                Console.WriteLine($"Студент {student.Name} {student.Surname}, {student.Gender}, Учится на {student.Сourse} курсе на кафедре {student.Department}, Успеваемость на уровне {student.Progress} баллов из 10");
            }
        }
        public static void PrintEmployee(Employee? employee)
        {
            if (employee.Position == null)
            {
                Console.WriteLine($"Сотрудник уволен");
            }
            else
            {
                Console.WriteLine($"Сотрудник {employee.Name} {employee.Surname}, {employee.Gender}, работает в должности {employee.Position}. Опыт работы {employee.Experience} лет, заработная плата в месяц - {employee.Salary} долл США");
            }
        }
        public static void DeleteEmployee(Employee? employee)
        {
            employee.Salary = -1;
            employee.Experience = -1;
            employee.Position = null;
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
            employee.Salary = employee.Salary + a / 100 * employee.Salary;
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
                Progress = 5,
                Name = "Никита",
                Gender = "Мужчина",
                Surname = "Горндонов",
                Age = 18
            };

            Employee Nikitaemployee = new Employee()
            {
                Position = "Официант",
                Experience = 5,
                Salary = 500,
                Name = "Никита",
                Gender = "Мужчина",
                Surname = "Страдатель",
                Age = 44
            };


            Console.WriteLine(Nikitaemployee.Salary);
            LevelUp(Nikitaemployee, 55.5);
            Console.WriteLine(Nikitaemployee.Salary);

            Nikita.Print(Nikita);
            Nikita.Print(Nikitaemployee);
            Nikita.Print(NikitaStudent);

            Console.WriteLine();

            PrintEmployee(Nikitaemployee);
            PrintStudent(NikitaStudent);

            DeleteEmployee(Nikitaemployee);
            DeleteStudent(NikitaStudent);
            
            Console.WriteLine();

            PrintEmployee(Nikitaemployee);
            PrintStudent(NikitaStudent);

            Console.WriteLine();

            Person[] arr = new Person[] { Nikita, NikitaStudent, Nikitaemployee };

            foreach (Person person in arr)
            {
                person.Base();
            }
        }
    }
}