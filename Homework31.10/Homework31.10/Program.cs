using ConsoleApp1;
using System;

namespace ConsoleApp1
{

    public class Person
    {
        public string _name { get; set; }
        public string _surname { get; set; }
        public int _intage { get; set; }

        public string _gender { get; set; }



        public Person(string Name, string Surname, string Gender, int Age)
        {
            _name = Name;
            _surname = Surname;
            _gender = Gender;
            _intage = Age;
        }
        public Person() : this("Unknown", "Unknown", "Unknown", -1) { }


        public string GetAge()
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
        public void SetAge(int value)
        {
            _intage = value;
        }





    }
    public class Student
    {
        public Person Person { get; set; }
        public string _university { get; set; }
        public int _course { get; set; }
        public string _faculty { get; set; }

        public Student(Person person, string University, int Course, string Faculty)
        {
            Person = person;
            _university = University;
            _course = Course;
            _faculty = Faculty;

        }
        public string GetCourse()
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
        public void SetCourse(int value)
        {
            _course = value;
        }
        public Student() : this(new(), "Unknown", -1, "Unknown") { }
    }

    public class Employee
    {
        public Person Person { get; set; }
        public string _job { get; set; }
        public double _salarymonth { get; set; }
        public double _experience { get; set; }


        public Employee(Person person, string Job, double Salarymonth, double Experience)
        {
            Person = person;
            _job = Job;
            _salarymonth = Salarymonth;
            _experience = Experience;
        }


        public Employee() : this(new(), "Unknown", -1, -1) { }
    }







    internal class Program
    {
        static void PersonOutput(Person person)
        {
            Console.Write($"{person._surname} {person._name} {person._gender}, ему {person.GetAge()} лет. ");
        }

        static void StudentOutput(Student student)
        {
            Console.WriteLine("");
            PersonOutput(student.Person);
            Console.Write($"Учится в {student._university} на факультете {student._faculty} на {student.GetCourse()} курсе");
        }

        static void EmployeeOutput(Employee employee)
        {
            Console.WriteLine("");
            PersonOutput(employee.Person);
            Console.Write($"Работает {employee._job} уже более {employee._experience} лет и получает {employee._salarymonth}$ в месяц");
        }

        static void SalaryIncrease(Employee employee)
        {
            Console.WriteLine("");
            Console.WriteLine($"Работник {employee.Person._surname} {employee.Person._name} работает уже более {employee._experience} лет и просит повышения зарплаты. Сейчас он получает {employee._salarymonth}$. На сколько % мы готовы повысить?");
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
                    double result = (employee._salarymonth * (1 + percent / 100));
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
                _name = "Саня",
                _surname = "Бабик",
                _intage = 24,
                _gender = "Мужыыык",
            };

            Student b = new()
            {
                Person = new()
                {
                    _name = "Санёк",
                    _surname = "Бобик",
                    _intage = 14,
                    _gender = "Мужчинка",
                },
                _course = 6,
                _faculty = "ПСФ",
                _university = "БНТУ",


            };

            Employee c = new()
            {
                Person = new()
                {
                    _name = "Сашуля",
                    _surname = "Боблайтер",
                    _intage = 76,
                    _gender = "Дед",
                },
                _experience = 4,
                _job = "директором твиттера",
                _salarymonth = 500,

            };


            PersonOutput(a);
            StudentOutput(b);
            EmployeeOutput(c);
            SalaryIncrease(c);

            b = StudentDeduction();
            Console.WriteLine($"{b._course}");

            c = EmployeeDeduction();
            Console.WriteLine($"{c.Person._name}");
        }
    }
}













