using ConsoleApp1;
using System;

namespace ConsoleApp1
{

    public class Person
    {
        public string _name;
        public string _surname;
        public int _intage;
        public string _gender;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        public string Age
        {
            get
            {
                if (_intage < 0)
                {
                    return "Недопустимое значение";
                }
                else
                {
                    return _intage.ToString();
                }
            }
        }
        public Person(string Name, string surname, string gender, int age)
        {
            _name = Name;
            _surname = surname;
            _gender = gender;
            _intage = age;
        }
        public Person() : this("Unknown", "Unknown", "Unknown", -1) { }
    }

    public class Student
    {
        public Person Person { get; set; }
        public string _university;
        public int _course;
        public string _faculty;

        public string University
        {
            get { return _university; }
            set { _university = value; }
        }
        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }

        public string Course
        {
            get
            {
                if (_course <= 0 || _course >= 7)
                {
                    return "ОШИБКА!";
                }
                else
                {
                    return _course.ToString();
                }
            }
        }
        public Student(Person person, string university, int course, string faculty)
        {
            Person = person;
            _university = university;
            _course = course;
            _faculty = faculty;
        }
        public Student() : this(new(), "Unknown", -1, "Unknown") { }
    }

    public class Employee
    {
        public Person Person { get; set; }
        public string _job;
        public double _salarymonth;
        public double _experience;

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }
        public double Salarymonth
        {
            get { return _salarymonth; }
            set { _salarymonth = value; }
        }
        public double Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public Employee(Person person, string job, double salarymonth, double experience)
        {
            Person = person;
            _job = job;
            _salarymonth = salarymonth;
            _experience = experience;
        }

        public Employee() : this(new(), "Unknown", -1, -1) { }
    }

    internal class Program
    {
        static void PersonOutput(Person person)
        {
            Console.Write($"{person.Surname} {person.Name} {person.Gender}, ему {person.Age} лет. ");
        }

        static void StudentOutput(Student student)
        {
            Console.WriteLine("");
            PersonOutput(student.Person);
            Console.Write($"Учится в {student.University} на факультете {student.Faculty} на {student.Course} курсе");
        }

        static void EmployeeOutput(Employee employee)
        {
            Console.WriteLine("");
            PersonOutput(employee.Person);
            Console.Write($"Работает {employee.Job} уже более {employee.Experience} лет и получает {employee.Salarymonth}$ в месяц");
        }

        static void SalaryIncrease(Employee employee)
        {
            Console.WriteLine("");
            Console.WriteLine($"Работник {employee.Person.Surname} {employee.Person.Name} работает уже более {employee.Experience} лет и просит повышения зарплаты. Сейчас он получает {employee.Salarymonth}$. На сколько % мы готовы повысить?");
            double percent = Convert.ToDouble(Console.ReadLine());
            if (percent < 0 || percent > 100)
            {
                Console.WriteLine("Вы несёте какую-то дичь");
            }
            else
            {
                if (percent < 10 || percent > 70)
                {
                    Console.WriteLine("Отнеситесь, пожалуйста, серьезно!");
                }
                else
                {
                    double result = (employee.Salarymonth * (1 + percent / 100));
                    Console.WriteLine($"С учетом повышения, зарплата будет {result}$.");
                }
            }
        }

        static Student StudentDeduction()
        {
            return new();
        }

        static Employee EmployeeDeduction()
        {
            return new();
        }

        static void Main(string[] args)
        {
            Person a = new()
            {
                Name = "Саня",
                Surname = "Бабик",
                _intage = 24,
                Gender = "Мужыыык",
            };

            Student b = new()
            {
                Person = new()
                {
                    Name = "Санёк",
                    Surname = "Бобик",
                    Gender = "Мужчинка",
                    _intage = 14,
                },
                _course = 6,
                Faculty = "ПСФ",
                University = "БНТУ",
            };

            Employee c = new()
            {
                Person = new()
                {
                    Name = "Сашуля",
                    Surname = "Боблайтер",
                    Gender = "Дед",
                    _intage = 76,
                },
                Experience = 4,
                Job = "директором твиттера",
                Salarymonth = 500,
            };

            PersonOutput(a);
            StudentOutput(b);
            EmployeeOutput(c);
            SalaryIncrease(c);
            b = StudentDeduction();
            Console.WriteLine($"{b.Course}");
            c = EmployeeDeduction();
            Console.WriteLine($"{c.Person.Name}");
        }
    }
}