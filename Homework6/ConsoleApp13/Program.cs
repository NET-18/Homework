using System;

namespace ConsoleApp13
{
        class Person
        {
            public string _name { get; set; }
            public string _surname { get; set; }
            public int _age { get; set; }
        public Person(string name, string surname, int age)
        {
            _name = name;
            _surname = surname;
            _age = age;
        }
        public Person(): this("Deleted", "Deleted", -1) { }
    }
        class Student
        {
            public string _university { get; set; }
            public string _department { get; set; }
            public int _course { get; set; }
            public Person person1 { get; set; }
        public Student(string university, string department, int course, Person person1)
        {
            _university = university;
            _department = department;
            _course = course;
            this.person1 = person1;
        }
        public Student(): this("Deleted", "Deleted", -1, new()) { }
    }
        class Employee
        {
            public string _job { get; set; }
            public int _salary { get; set; }
            public int _exp { get; set; }
            public Person person2 { get; set; }
        public Employee(string job, int salary, int exp, Person person2)
        {
            _job = job;
            _salary = salary;
            _exp = exp;
            this.person2 = person2;
        }
        public Employee(): this("Deleted", -1, -1, new()){}
    }
    internal class Program
    {
        static void Personinfo(Person person)
        {
            Console.WriteLine($"{person._name} {person._surname} is {person._age} years old");
        }
        static void StudentInfo(Student student)
        {
            Console.WriteLine();
            Personinfo(student.person1);
            Console.WriteLine($"He is study at {student._university} in {student._department} on {student._course}");

        }
        static void EmployeeInfo(Employee employee)
        {
            Console.WriteLine();
            Personinfo(employee.person2);
            Console.WriteLine($"{employee.person2._name} has {employee._exp} years experience. Make his {employee._job} very well and got a salary {employee._salary}");

        }
        static void Salary(Employee employee)
        {
            Console.WriteLine();
            Console.WriteLine($"Зарплата сотрудника {employee._salary} долларов");
            Console.WriteLine("На сколько % увеличить");
            int a = Convert.ToInt32(Console.ReadLine());
            int result = 1000 * a / 100;
            if (a > 0 && a < 100)
            {
                Console.Write($"Хорошо, прибавка к зарплате: {result} ");
                Console.WriteLine(" долларов");
            }
            else
            {
                Console.WriteLine("Так не бывает");
            }
        }
        static Student StudentDeduction()
        {
            return new();
        }
        static Employee EmployeeDefited()
        {
            return new();
        }
        static void Main(string[] args)
        {
            Person p = new()
            {
                _age = 18,
                _name = "Dmitry",
                _surname = "Mur",
            };
            Student s = new()
            {
                person1 = new()
                {
                    _age=20,
                    _name="Ivan",
                    _surname="git",
                },
                _course = 4,
                _department = "Optic",
                _university = "BNTU",

            };
            Employee d = new()
            {
                person2 = new()
                {
                    _age=33,
                    _name="Petya",
                    _surname="Goroh",
                },
                _exp = 3,
                _job = "pisyn",
                _salary = 1000,
            };
            Personinfo(p);
            StudentInfo(s);
            EmployeeInfo(d);
            Salary(d);
            s = StudentDeduction();
            Console.WriteLine($"{s.person1._surname}");
            d = EmployeeDefited();
            Console.WriteLine($"{d.person2._name}");

        }
    }
}