using System;

namespace ConsoleApp13
{
    internal class Program
    {
        class Person
        {
            public string _name;
            public string _surname;
            public int _age;
        }
        class Student
        {
            public string _university;
            public string _department;
            public int _course;
            public Person person1;
        }
        class Employee
        {
            public string _job;
            public int _salary;
            public int _exp;
            public Person person2;
        }
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
        static void salary(Employee employee)
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
        static void StudentDeduction(Student student)
        {
            Console.WriteLine();
            Console.WriteLine("Отчисляем студента");
            StudentInfo(student);
            Console.WriteLine("Отчислен с позором");
        }
        static void EmployeeDefited(Employee employee)
        {
            Console.WriteLine();
            Console.WriteLine("Увольняем и точка.");
            EmployeeInfo(employee);
            Console.WriteLine("Уволен и забыт");
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
            salary(d);
            StudentDeduction(s);
            EmployeeDefited(d);
        }
    }
}