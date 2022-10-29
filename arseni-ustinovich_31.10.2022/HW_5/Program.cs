using System;
using System.Linq.Expressions;

namespace HW_5
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string StringAge 
        { 
            get 
            { 
                if (Age <= -1) 
                { 
                    return "Unknown"; 
                }
                else
                {
                    return Age.ToString();
                }
            } 
        }   
        public string Gender { get; set; }
        public Person(string name, string surname, int age, string gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
        public Person() : this("Unknown", "Unknown", -1, "Unknown") { }
    } 
    public class Student
    {
        private string _grants;
        public Person Person { get; set; }
        public int Course { get; set; }
        public string StringCourse 
        {
            get
            {
                if (Course <= -1)
                {
                    return "Unknown";
                }
                else
                {
                    return Course.ToString();
                }
            }
        }
        public string Department { get; set; }
        public  string Grants
        {
            get
            {
                return _grants;
            }
            set
            {
                if (value.ToLower() != "fee-paying" || value.ToLower() != "free")
                {
                    _grants = "Unknown";
                }
                else
                {
                    _grants = value;
                }
            }
        }
        public Student(Person person, int course, string department, string grants)
        {
            Person = person;
            Course = course;
            Department = department;
            Grants = grants;
        }
        public Student() : this(new(), -1, "Unknown", "Unknown") { }
    }
    public class Employee
    {
        public Person Person { get; set; }
        public double MonthSalary { get; set; }
        public string StringMonthSalary
        {
            get
            {
                if (MonthSalary <= -1)
                {
                    return "Unknown";
                }
                else
                {
                    return MonthSalary.ToString();
                }
            }
        }
        public int Exp { get; set; }
        public string StringExp
        {
            get
            {
                if (Exp == -1)
                {
                    return "Unknown";
                }
                else
                {
                    return Exp.ToString();
                }
            }
        }
        public string Company { get; set; }
        public string Job { get; set; }
        public Employee(Person person, double monthSalary, int exp, string company, string job)
        {
            Person = person;
            MonthSalary = monthSalary;
            Exp = exp;
            Company = company;
            Job = job;
        }
        public Employee() : this(new(), -1, -1, "Unknown", "Unknown") { }
    }
    internal class Program
    {
        static void PersonInfo(Person person)
        {
            Console.WriteLine($"{person.Surname} {person.Name} is {person.StringAge}. Its gender is {person.Gender}.");
        }
        static void StudentInfo(Student student)
        {
            PersonInfo(student.Person);
            Console.WriteLine($"{student.Person.Name} is getting {student.Department} degree on a {student.Grants} basis. Current course is {student.StringCourse}.");
        }
        static void EmployeeInfo(Employee employee)
        {
            PersonInfo(employee.Person);
            Console.WriteLine($"{employee.Person.Name} is {employee.Job} working in {employee.Company} Working experience is {employee.StringExp}. Month salary is {employee.StringMonthSalary:f2}$.");
        }
        static void WageInc(Employee employee, int num)
        {
            employee.MonthSalary = employee.MonthSalary * (1 + num / 100.0);
        }
        static Employee FireEmplyee()
        {
            return new();
        }
        static Student ExpelStudent()
        {
            return new();
        }
        static void Main(string[] args)
        {
            Person myPerson = new()
            {
                Name = "Lupa",
                Surname = "Megaza",
                Age = 25,
                Gender = "Horse",
            };
            
            Student myStudent = new()
            {
                Person = new()
                {
                    Name = "Makaka",
                    Surname = "Faka",
                    Age = 21,
                    Gender = "Lolipop"
                },
                Course = 8,
                Department = "Wizardy and Alchemistry",
                Grants = "fee-paying",
            };
            
            Employee myEmployee = new()
            {
                Person = new()
                {
                    Name = "Alesha",
                    Surname = "Popocivh",
                    Age = 42,
                    Gender = "Super Male"
                },
                MonthSalary = 1500,
                Exp = 20,
                Company = "Guardians of Rostov inc.",
                Job = "Senior Fool",
            };

            PersonInfo(myPerson);
            Console.WriteLine();
            
            StudentInfo(myStudent);
            Console.WriteLine();
            
            EmployeeInfo(myEmployee);
            Console.WriteLine();

            int risingSalary = 90;
            Console.WriteLine("Rising salary is about {0}%", risingSalary);
            WageInc(myEmployee, risingSalary);
            EmployeeInfo(myEmployee);
            Console.WriteLine();

            Console.WriteLine("Firing employee...");
            myEmployee = FireEmplyee();
            EmployeeInfo(myEmployee);
            Console.WriteLine();

            Console.WriteLine("Expeling student...");
            myStudent = ExpelStudent();
            StudentInfo(myStudent);
            Console.WriteLine();

        }
    }
}